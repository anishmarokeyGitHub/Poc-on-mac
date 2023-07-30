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