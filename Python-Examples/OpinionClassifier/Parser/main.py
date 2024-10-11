import os
import json
import string
from pprint import pprint
from pymystem3 import Mystem
import re
import pandas as pd

import matplotlib as mpl
import matplotlib.pyplot as plt
import numpy as np

data_root = "datatest/"

fnames = {
    'item_id': 'item_id',
    'row_data': 'row_data',
    'film_id': 'film_id',
    'user_id': 'user_id',
    'user_name': 'user_name',
    'film_name': 'film_name',
    'review_mark': 'review_mark',
}


stop_list = ["c",
             "а", "алло",
             "без", "белый", "близко", "более", "больше", "большой", "будем", "будет",
             "будете", "будешь", "будто", "буду", "будут", "будь", "бы", "бывает", "бывь", "был", "была",
             "были", "было", "быть",
             "в", "важная", "важное", "важные", "важный", "вам", "вами", "вас", "ваш",
             "ваша", "ваше", "ваши", "вверх", "вдали", "вдруг", "ведь", "везде", "вернуться", "весь",
             "взять", "вид", "видел", "видеть", "вместе", "вне", "вниз", "внизу", "во",
             "вокруг", "вон", "вообще", "вопрос", "восемнадцатый", "восемнадцать", "восемь", "восьмой", "вот",
             "впрочем", "все", "всегда", "всего", "всем", "всеми", "всему", "всех", "всею",
             "всю", "всюду", "вся", "всё", "второй", "вы", "выйти",
             "г",
             "где",
             "да",
             "давать", "давно", "даже", "далекий", "далеко", "дальше", "даром", "дать", "два",
             "двадцатый", "двадцать", "две", "двенадцатый", "двенадцать", "двух", "девятнадцатый",
             "девятнадцать", "девятый", "девять", "действительно", "дел", "делал", "делать", "делаю",
             "десятый", "десять", "для", "до", "долго", "должен", "должно", "должный", "другая", "другие",
             "других", "друго", "другое", "другой",
             "е", "его", "ее", "ей", "ему", "если", "есть", "еще", "ещё", "ею", "её", "ж", "же", "за", "занят",
             "занята", "занято", "заняты", "затем", "зато", "зачем", "здесь", "значит", "значить",
             "и",
             "из", "или", "им", "имеет", "имел", "именно", "иметь", "ими", "иногда", "их",
             "к",
             "каждая", "каждое", "каждые", "каждый", "как", "какая", "какой", "кем", "когда", "кого", "ком",
             "кому", "конец", "конечно", "которая", "которого", "которой", "которые", "который", "которых",
             "кроме", "кругом", "кто", "куда",
             "лежать", "лет", "ли", "лицо", "лишь", "лучше",
             "м",
             "маленький", "мало", "между", "меля", "менее", "меньше", "меня", "место", "миллионов", "мимо",
             "мне", "много", "многочисленная", "многочисленное", "многочисленные", "многочисленный", "мной", "мною",
             "мог", "могу", "могут", "мож",
             "может", "можно", "можхо", "мои", "мой", "мочь", "моя", "моё", "мы",
             "на",
             "наверху", "над", "надо",
             "наиболее", "найти", "наконец", "нам", "нами", "нас", "начала", "начать", "наш", "наша", "наше", "наши",
             "не", "него", "недавно", "недалеко", "нее", "ней", "некоторый", "нельзя", "нем", "немного", "нему",
             "непрерывно", "нередко", "несколько", "нет", "нею", "неё", "ни", "нибудь", "ниже", "низко", "никогда",
             "никто", "никуда", "ним", "ними", "них", "ничего", "ничто", "но", "новый", "ну", "нужно", "нужный", "нх",
             "о",
             "об", "оба", "обычно", "один", "одиннадцатый", "одиннадцать", "однажды", "однако", "одного",
             "одной", "оказаться", "около", "он", "она", "они", "оно", "опять", "особенно", "остаться", "от",
             "откуда", "отовсюду", "отсюда", "очень",
             "первый", "перед", "писать", "плечо", "по", "под",
             "позже", "пойти", "пока", "пол", "получить", "помнить", "понимать", "понять", "пор", "пора", "после",
             "посреди", "потом", "потому", "почему", "почти", "правда", "прекрасно", "при", "про", "просто", "против",
             "процентов", "пятнадцатый", "пятнадцать", "пятый", "пять", "раз", "разве", "рано", "раньше", "рядом",
             "с",
             "сам", "сама", "сами", "самим", "самими", "самих", "само", "самого", "самой", "самом", "самому", "саму",
             "самый", "свое", "своего", "своей", "свои", "своих", "свой", "свою", "сеаой", "себе", "себя", "сегодня",
             "седьмой", "сейчас", "семнадцатый", "семнадцать", "семь", "сидеть", "сила", "сих", "сказал", "сказала",
             "сказать", "сколько", "слишком", "сначала", "снова", "со", "собой", "собою", "совсем", "спасибо",
             "спросить",
             "сразу", "стал", "старый", "стать", "стол", "сторона", "стоять", "страна", "суть", "считать",
             "т",
             "та", "так", "такая", "также", "таки", "такие", "такое", "такой", "там", "твои", "твой", "твоя", "твоё",
             "те", "тебе", "тебя", "тем", "теми", "теперь", "тех", "то", "тобой", "тобою", "тогда", "того", "тоже",
             "только", "том", "тому", "тот", "тою", "третий", "три", "тринадцатый", "тринадцать", "ту", "туда", "тут",
             "ты", "тысяч",
             "у",
             "уж", "уже",
             "хоть",
             "хотя", "хочешь",
             "час",
             "часто", "часть", "чаще", "чего", "чем", "чему", "через", "четвертый", "четыре", "четырнадцатый",
             "четырнадцать", "что", "чтоб", "чтобы", "чуть",
             "шестнадцатый",
             "шестнадцать", "шестой", "шесть",
             "эта", "эти", "этим", "этими", "этих", "это", "этого", "этой", "этом", "этому", "этот", "эту",
             "я", "являюсь"
             ]

def Lemmatizator(text: str) -> str:
    m = Mystem()
    lemmas = m.lemmatize(text)
    res = ''.join(lemmas)
    # print(res)
    return res


def BachLemmatizasator(texts: list) -> list:
    res = ' , '.join(texts)
    res = Lemmatizator(res)
    res = res.split(' , ')
    res[-1] = res[-1].strip()

    return res


def PrepareText(text: str) -> str:
    # Преобразование текста в нижний регист
    text = text.lower()

    # Удаление цифр
    text = re.sub(r'\d+', "", text)

    # Удаление пунктуации  [!”#$%&’()*+,-./:;<=>?@[\]^_`{|}~]:
    text = text.translate(str.maketrans('--—.,', '     ', ))
    text = text.translate(str.maketrans('', '', string.punctuation + '«»…'))

    # Удаление пробельных символов (whitespaces);
    text = text.strip()

    # Удаление стоп слов;
    l_text = text.split(' ')
    l_clear_text = []
    for item in l_text:
        if len(item) < 2: continue
        if item in stop_list: continue
        l_clear_text.append(item)

    text = ' '.join(l_clear_text)

    # Лемматизация
    text = Lemmatizator(text)

    return text


def main():
    positiv_list = []
    negative_list = []
    netral_list = []

    reviews_list = []
    reviews_id_list = []
    reviews_marks_list = []

    col_review = 'review'

    root_path = "data/"
    iinn = 0
    for (root, dirs, files) in os.walk(root_path):
        if not files: continue
        iinn += 1

        for file in files:
            path = f"{root}/{file}"

            with open(path, 'r', encoding='utf-8') as f:
                data = json.load(f)

            text = data[fnames['row_data']]

            text = PrepareText(text)

            reviews_list.append(text)
            reviews_id_list.append(data[fnames['item_id']])
            reviews_marks_list.append(data[fnames['review_mark']])

            if data[fnames['review_mark']] == 'N':
                netral_list.append({col_review: text, "id": data[fnames['item_id']]})
            if data[fnames['review_mark']] == 'good':
                positiv_list.append({col_review: text, "id": data[fnames['item_id']]})
            if data[fnames['review_mark']] == 'bad':
                negative_list.append({col_review: text, "id": data[fnames['item_id']]})

            pprint(f"done: {iinn}")


    df_pos = pd.DataFrame.from_records(positiv_list)
    df_bad = pd.DataFrame.from_records(negative_list)
    df_n = pd.DataFrame.from_records(netral_list)

    bach_size = 1000
    reviews_list_lemm = []
    for i in range(0, len(reviews_list), bach_size):
        bach = reviews_list[i:i + bach_size]
        bach = BachLemmatizasator(bach)
        reviews_list_lemm.extend(bach)
        print(f"progres:\ti:{i} from {len(reviews_list)}\t (s:{len(bach)})")

    df_review = pd.DataFrame(list(zip(reviews_id_list, reviews_marks_list, reviews_list_lemm)),
                             columns=['r_id', 'mark', 'review'])
    df_review.to_csv('reviews.csv', mode='a', index=False, sep='\t', encoding='utf-8')

def writeListWithId(path: str, l: list):
    for index, item in enumerate(l):
        review_path = path + str(item[0]) + ".txt"
        os.makedirs(os.path.dirname(review_path), exist_ok=True)
        with open(f"{review_path}", 'w', encoding='utf-8') as f:
            f.write(item[2])

        if index % 100 == 0:
            print(f"{path}\t{index}")


def splitCsv():
    df = pd.read_csv('reviews.csv', sep='\t', encoding='utf-8')
    pprint(df)

    df_good = df[df['mark'] == 'good']
    df_bad = df[df['mark'] == 'bad']
    df_nnn = df[df['mark'] == 'N']

    pprint(df_good)
    pprint(df_bad)
    pprint(df_nnn)
    print(f"g:{len(df_good)}\tb:{len(df_bad)}\tn:{len(df_nnn)}")

    data = {'Хорошие': len(df_good),
            'Плохие': len(df_bad),
            'Нейтральные': len(df_nnn),
            }
    group_data = list(data.values())
    group_names = list(data.keys())

    plt.rcParams.update({'figure.autolayout': True})
    fig, ax = plt.subplots()
    x = np.arange(3)
    plt.bar(x, group_data)
    plt.xticks(x, group_names)
    plt.show()



    z_good = list(zip(df_good['r_id'].tolist(), df_good['mark'].tolist(), df_good['review'].tolist()))
    writeListWithId("data_kino/train/pos/", z_good[:4000])
    writeListWithId("data_kino/test/pos/", z_good[4000:5000])

    z_bad = list(zip(df_bad['r_id'].tolist(), df_bad['mark'].tolist(), df_bad['review'].tolist()))
    writeListWithId("data_kino/train/neg/", z_bad[:4000])
    writeListWithId("data_kino/test/neg/", z_bad[4000:5000])

    z_uns = list(zip(df_nnn['r_id'].tolist(), df_nnn['mark'].tolist(), df_nnn['review'].tolist()))
    writeListWithId("data_kino/train/uns/", z_uns[:4000])
    writeListWithId("data_kino/test/uns/", z_uns[4000:4947])


if __name__ == "__main__":
    # main - сбор json-файлов, очистка, лематизация и формирование итогового review.csv
    main()
    
    # splitCsv - формирование файловой структуры из "review.csv" для работы  tf.keras.utils.text_dataset_from_directory
    splitCsv()
