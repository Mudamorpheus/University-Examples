import tensorflow as tf

import bow_mpl
import mlp_seq
import cnn_model
import lstm_model


def main(model: tf.keras.Model, test_ds):
    model.evaluate(test_ds)


def test_it(prefix_name: str, getter_dataset):
    _, _, test_ds, _ = getter_dataset()

    model_file_name = f"{prefix_name}_model.h5"
    test_model = tf.keras.models.load_model(model_file_name)
    main(test_model, test_ds)
    print(f"{__name__} Done for {prefix_name}")


if __name__ == '__main__':

    # создание, тренировка и сохранение моделей
    #bow_mpl.main()
    #mlp_seq.main()
    #cnn_model.main()
    #lstm_model.main()

    # загрузка готовых моделей и прогон на тестовых данных
    test_it(bow_mpl.prefix_name, bow_mpl.get_datasets)
    #test_it(mlp_seq.prefix_name, mlp_seq.get_datasets)
    #test_it(cnn_model.prefix_name, cnn_model.get_datasets)
    #test_it(lstm_model.prefix_name, lstm_model.get_datasets)

    print(f"{__name__} Done")
