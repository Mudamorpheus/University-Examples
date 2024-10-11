console.log("Starting content !!!!")

const TAG = "reader::"

const body = document.querySelector("body");

function getSlashId(keys, slash_path){
    let path = slash_path.split('/')
    for (key of keys){
        let f_idx = path.indexOf(key)
        if (f_idx == -1) continue;
        if (path.length-1 < f_idx) continue;

        return path[f_idx+1];        
    }
    return undefined
}

function getFilmId(slash_path){
    let keys=["film","series"];
    return getSlashId(keys,slash_path);
}

function getUserId(slash_path){
    let keys=["user"];
    return getSlashId(keys,slash_path);
}

function getBreadFilmName(){
    let film_id_bread = document.querySelectorAll(".breadcrumbs__item a");
    console.log("film_id_bread.length : "+ film_id_bread.length)
    if (film_id_bread.length>1) return undefined;
    if (film_id_bread.length==0) return undefined;

    fid = getFilmId(film_id_bread[0].getAttribute("href"));

    if (fid)
        return film_id_bread[0].textContent;
    else return undefined;    
}

function getBreadFilmId(){
    let film_id_bread = document.querySelectorAll(".breadcrumbs__item a");
    console.log("film_id_bread.length : "+ film_id_bread.length)
    if (film_id_bread.length>1) return undefined;

    return getFilmId(item.getAttribute("href"));
}

if (body){
    console.log(location)
    console.log(location.pathname)

    let url_film_id = getFilmId(location.pathname);
    let bread_film_name = getBreadFilmName();

    let user_name=body.querySelector(".nick_name")?.textContent;
    if (!user_name){
        user_name=body.querySelector(".profile_name a")?.textContent;
    }

    let user_id=undefined;
    if (user_name){
        user_id = getUserId(location.pathname);
    }
     
    

    console.log("uFid:"+url_film_id+"\tbrName:"+bread_film_name)

    const items = document.querySelectorAll(".reviewItem")
    console.log(`review items\t:${items.length}`);
    [...items].map((item) => {
        (async ()=>{

            review_user_name = item.querySelector(".profile_name a[itemprop=\"name\"]")
            if (review_user_name){
                user_name = review_user_name.textContent;
                user_id = getUserId(review_user_name.getAttribute("href"));
            }

            let reviewed_film_name=undefined;
            let reviewed_film_id=undefined;
            reviewed_film_node = item.querySelector("p[itemprop=\"itemReviewed\"] a[itemprop=\"url\"]")
            if (reviewed_film_node){
                reviewed_film_name = reviewed_film_node.textContent; // в span-е
                reviewed_film_id = getFilmId(reviewed_film_node.getAttribute("href"));
            }
            
            let review_mark_val = "N"
            {
                let review_mark = item.querySelector(".response")
                if (review_mark.classList.contains("good")) review_mark_val="good"
                else if (review_mark.classList.contains("bad")) review_mark_val="bad"
            }

            let review_date="undef"
            {
                let r_ndoe = item.querySelector(".response span.date")
                if (r_ndoe)
                    review_date = r_ndoe.textContent
            }

            let useful="undef"
            {
                //:nth-child(3)
                let r_ndoe = item.querySelectorAll(".response ul.useful li")
                if (r_ndoe?.length>=3){
                    useful = r_ndoe[2].textContent;
                    useful+= `:d:${r_ndoe[1].innerText.trim()}`;
                }
            }

            let data = {
                url : location.pathname,
                item_id: item.getAttribute("data-id"),
                film_id: url_film_id||reviewed_film_id,
                film_name: bread_film_name||reviewed_film_name,
                review_mark: review_mark_val,
                user_id: user_id,
                user_name: user_name,
                review_date: review_date,
                review_useful : useful,                
                // row_body: item.outerHTML,                
                row_data: item.querySelector("p span[itemprop=\"reviewBody\"]").innerText,
            };

            let responce = await fetch(`http://127.0.0.1:5000/ping`,{
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json;charset=utf-8'
                },
                body: JSON.stringify(data)
            });
            let commits = await responce.json();
            console.log(`RRRR  flask data:\t${ JSON.stringify(commits)}`)
        })();
    });
}
else{
    console.log("FAil bOdy !!!")
}  