import matplotlib.pyplot as plt
import tensorflow as tf
from keras.utils.vis_utils import plot_model

from keras.layers import TextVectorization
from keras import layers

import os

dataset_root = "dataset/kinopoisk5000/"
batch_size = 32

prefix_name = "Mlp_bow"

# Model constants.
max_features = 20000  # 70%

epochs = 2


def get_datasets():

    print(os.path.abspath(dataset_root + "train"))

    raw_train_ds = tf.keras.utils.text_dataset_from_directory(
        dataset_root + "train",
        batch_size=batch_size,
        validation_split=0.2,
        subset="training",
        seed=1337,
        label_mode='categorical'
    )
    raw_val_ds = tf.keras.utils.text_dataset_from_directory(
        dataset_root + "train",
        batch_size=batch_size,
        validation_split=0.2,
        subset="validation",
        seed=1337,
        label_mode='categorical',
    )
    raw_test_ds = tf.keras.utils.text_dataset_from_directory(
        dataset_root + "/test", batch_size=batch_size,
        label_mode='categorical'
    )

    print(f"Number of batches in raw_train_ds: {raw_train_ds.cardinality()}")
    print(f"Number of batches in raw_val_ds: {raw_val_ds.cardinality()}")
    print(f"Number of batches in raw_test_ds: {raw_test_ds.cardinality()}")

    vectorize_layer = TextVectorization(
        max_tokens=max_features,
        output_mode='tf_idf'
    )

    text_ds = raw_train_ds.map(lambda x, y: x)
    vectorize_layer.adapt(text_ds)

    def vectorize_text(text, label):
        text = tf.expand_dims(text, -1)
        return vectorize_layer(text), label

    train_ds = raw_train_ds.map(vectorize_text)

    val_ds = raw_val_ds.map(vectorize_text)
    test_ds = raw_test_ds.map(vectorize_text)

    return train_ds, val_ds, test_ds, vectorize_layer


def main():
    train_ds, val_ds, test_ds, vectorize_layer = get_datasets()

    activation_inner = 'tanh'
    # activation_inner = 'relu'
    activation_last = 'softmax'

    inputs = tf.keras.Input(shape=(vectorize_layer.vocabulary_size(),), dtype="float64")
    x = layers.Dense(128, activation=activation_inner)(inputs)

    x = layers.Dense(64, activation=activation_inner)(x)
    x = layers.Dropout(0.5)(x)
    x = layers.Dense(16, activation=activation_inner)(x)
    x = layers.Dropout(0.5)(x)

    predictions = layers.Dense(3, activation=activation_last, name="predictions")(x)

    model = tf.keras.Model(inputs, predictions)

    model.compile(loss=tf.keras.losses.categorical_crossentropy, optimizer="adam", metrics=["accuracy"])

    model.summary()

    plot_model(model, to_file=f'{prefix_name}_model_plot.png', show_shapes=True, show_layer_names=True)

    history = model.fit(train_ds,
                        validation_data=val_ds,
                        epochs=epochs,
                        verbose=1,
                        )
    print(f"start history:\t{history}")
    history = history.history

    for item in history:
        print(f"{item}:\t{history[item]}")

    loss = history['loss']
    val_loss = history['val_loss']

    '''
    Вывод графика потерь при обучении и валидации
    '''
    # epochs = range(1, len(loss) + 1)
    plt.figure(num=f'{prefix_name}. Потери')
    plt.plot(history['loss'], 'b', label='Потери при обучении')
    plt.plot(history['val_loss'], 'bo', label='Потери при валидации')
    plt.title(f'{prefix_name}: Потери при обучении и валидации')
    plt.xticks(range(0, epochs + 1))
    plt.legend()

    plt.figure(num=f'{prefix_name}. Точность')
    plt.plot(history['accuracy'], label='Точность при обучении')
    plt.plot(history['val_accuracy'], label='Точность при валидации')
    plt.title(f'{prefix_name}: Точность при обучении и валидации')
    plt.xticks(range(0, epochs + 1))
    plt.legend()

    model.evaluate(test_ds)

    model.save(f"{prefix_name}_model.h5", save_format="h5")

    return model


if __name__ == '__main__':
    main()
    plt.show()
    print(f"{__name__} Done")