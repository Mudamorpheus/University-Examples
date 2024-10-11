import traceback
from pprint import pprint
import json
import re
from uuid import uuid4
import os

from flask import Flask, render_template, url_for, request, redirect, flash, jsonify
from flask_cors import CORS
from flask_sqlalchemy import SQLAlchemy
from datetime import datetime

app = Flask(__name__)
CORS(app)
print(f' app here:{app}')

app.secret_key = 'xyz'
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///kino_data.db'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

fnames = {
    'item_id': 'item_id',
    'row_data': 'row_data',
    'film_id': 'film_id',
    'user_id': 'user_id',
    'user_name': 'user_name',
    'film_name': 'film_name',
    'review_mark':'review_mark',
}

memory_database = {}

def makePathToReview(v: dict) -> str:
    rl = ['data']
    l = v.keys()
    if fnames['film_id'] in l:
        rl.append(v[fnames['film_id']])
        if fnames['user_id'] in l:
            rl.append(v[fnames['user_id']])

    if fnames['item_id'] in l:
        rl.append(f"{v[fnames['item_id']]}.json")
    else:
        rl.append(f"{uuid4()}.json")

    return '/'.join(rl)


@app.route('/ping', methods=['POST', 'GET'])
def ping():
    print("Ping here")

    if request.method == "POST":
        print(f"Ping here POST\targs:{len(request.form)}")
    if request.method == "GET":
        print(f"Ping here GET\targs:{len(request.args)}")

    if request.is_json:
        j_keys = request.json.keys()

        review_path = makePathToReview(request.json)
        pprint(review_path)

        j_data = request.json        
        j_data['row_data'] = re.sub(r'\s+', ' ', j_data['row_data'])        

        os.makedirs(os.path.dirname(review_path),exist_ok=True)
        with open(f"{review_path}", 'w', encoding='utf-8') as f:
            json.dump(request.json, f, ensure_ascii=False, indent=4)

    report = {
        "status": "Ok",
        "body": "default body",
        "some_code": 1,
    }

    return jsonify(report)

if __name__ == "__main__":
    app.run(debug=False, host='0.0.0.0')
