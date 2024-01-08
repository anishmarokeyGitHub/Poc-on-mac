sample query 

http://localhost:5125/ui/altair
query {
    products{
      id,
      quantity
  } 
}
query {
product(id: 2){
  name,
  quantity
}
}
query {
    products{
      id,
      quantity
  },
    product(id: 2){
  name,
  quantity
} 
}

postman

QUERY
query($id: Int!)  {
   
product(id: $id){
  name,
  quantity
} 
}

GRAPHQL VARIABLES
{"id" :1 }

Postman Post Query:
http://localhost:5125/graphql
Body => Raw =Josn
  {
  "query": "query { product(id: 2) { name quantity } }"
}

turorial: https://www.google.com/search?q=graphql+asp.net+core+6&sca_esv=584187651&tbm=vid&sxsrf=AM9HkKlYsiBMH6yruLWpwL7wjgPQPv_MWQ:1700540793501&source=lnms&sa=X&ved=2ahUKEwi_trCPoNSCAxW-SmwGHau4DgAQ_AUoAnoECAEQBA&biw=1378&bih=758&dpr=2#fpstate=ive&vld=cid:55540bb0,vid:gEApqKuWvSg,st:0
