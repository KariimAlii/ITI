// 1 - Download the following json file and import it into a collection named “zips” into “iti” database

mongoimport --version

mongoimport --uri "mongodb://127.0.0.1:27017/ITI" --collection 'zips' --file 'zips.json'

db.zips.find()

// find all documents which contains data related to “NY” state

db.zips.find({state:"NY"})

// 3 – find all zip codes whose population is greater than or equal to 1000

db.zips.find({pop:{$gte:1000}})

// 4 – add a new boolean field called “check” and set its value to true for “PA” and “VA” state 


db.zips.updateMany(
    {
        state: {$in:['PA','VA']}
    },
    {
        $set:{check : true}
    }
)


db.zips.find({$or : [{state:'VA'},{state:'PA'}]})


// 5 – using zip codes find all cities whose latitude is between 55 and 65 and show the population only.

db.zips.find(
    {
        "loc.1": {$gte:55,$lte:66}
    },
    {
        loc:1,
        pop:1
    }
)

db.zips.find(
    {
        "loc.1": {$gte:55,$lte:66}
    },
    {
        pop:1
    }
)

// 6 – create index for states to be  able to select it quickly 
// and check any query explain using the index only.
db.zips.createIndex({state:1})
db.zips.getIndexes()
// 7 – increase the population by 0.2 for all cities which doesn't located in “AK” nor “NY”
db.zips.find({ state : {$nin : ["AK","NY"]} })

db.zips.updateMany(
    {
        state : {$nin : ["AK","NY"]}
    },
    {
        $mul : {
            pop : Decimal128("1.20")
        }
    }
)
 
// 8 – update  only one city whose longitude is lower than -71 
// and is not located in “MA” state, 
// set its population to 0 
// if zipcode population less than 200.
db.zips.findOne({
        "loc.0" : {$lt : -71},
        state : {$ne : "MA"},
        pop : {$lt : 200}
    })
db.zips.updateOne(
    {
        "loc.0" : {$lt : -71},
        state : {$ne : "MA"},
        pop : {$lt : 200}
    },
    {
        $set: {pop : 0} 
    }
)    
 
// 9 – update all documents whose city field is a string,
//  rename its city field to be country 
// and if there isn't any, 
// add new document the same as the first document in the database
//  but change the _id to avoid duplications. 
// Hint: use Variables

db.zips.find({}).count()
db.zips.find({city : {$type : "string"}}).count()

var requiredDocuments = db.zips.find({city : {$type : "string"}})

requiredDocuments

requiredDocuments.count()

db.zips.updateMany (
    {
        city : {$type : "string"}
    },
    {
        $rename : {'city':'country'}
    }
)




//    Part2
//==============

// 1. Get sum of population that state in PA, MA

db.zips.find({ state :'MA'})
db.zips.find({ $or:[{state:'PA'},{state:'MA'}] })
db.zips.find({ state : {$in: ['PA','MA']} })


db.zips.aggregate([
    {$match: { state : {$in: ['PA','MA']} } },
    {$group: { _id:"$state" , total :{$sum:"$pop"} }}
])
// 2. Get only 5 documents that state not equal to PA, KA
db.zips.find({state : {$nin:['PA','MA']}})

db.zips.aggregate([
    { $match : { state : {$nin:['PA','MA']} } },
    { $limit : 5}
])

// 3. Get sum of population that state equal to AK 
// and their latitude between 55, 65
db.zips.find({ state:"AK" , "loc.1" : {$gte:55} , "loc.1" : {$lte:65}  })
db.zips.aggregate([
    { $match:{state:"AK" , "loc.1" : {$gte:55} , "loc.1" : {$lte:65} } },
    { $group: {_id:"$state" , "Total Population" : {$sum : "$pop"}}}
])
// 4. Sort Population of document
// that state in AK, PA 
// and skip first 7 document

db.zips.aggregate([
    { $match: { state: {$in:['AK','PA']} } },
    {$sort:{pop:1}},
    {$skip:7}
])
// 5. Get smallest population and greatest population
// of each state 
// and save the result in collection named "mypop" 
// on your machine colleague 

db.zips.aggregate([
    { $match: {} },
    { $group: {  _id:"$state" , Minimum:{$min:"$pop"} , Maximum:{$max:"$pop"}  } },
    { $out: "mypop"}
])

db.mypop.find()
// 6. Write an aggregation expression to calculate
// the average population of a zip code (postal code) by state

db.zips.aggregate([
    { $match: {} },
    { $group : { _id:"$state" , "Average":{$avg:"$pop"} } },
    { $project: { "Average Population": { $toLong:{$ceil:"$Average"} } } }
])
// 7. Write an aggregation query with just a sort stage 
// to sort by (state, country), both ascending
db.zips.aggregate([
    { $match: {} },
    { $sort: {state:1,country:1} }
])
// 8. Write an aggregation query with just a sort stage 
// to sort by (state, country), both descending
db.zips.aggregate([
    { $match: {} },
    { $sort: {state:-1,country:-1} }
])
// 9. Calculate the average population of cities in California (abbreviation CA) 
// and New York (NY) (taken together) 
// with populations over 25,000
db.zips.aggregate([
    { $match: { pop:{$gte:25000} , state:{$in:['CA','NY']} } },
    { $project: { "Average Population": { $toLong:{$ceil:{$avg:"$pop"}} } } }
])

// 10.Return the average populations for cities in each state

db.zips.aggregate([
    { $match: {} },
    { $group : { _id:{state:"$state",city:"$country"} , "Average":{$avg:"$pop"} } },
    { $project: { "Average Population": { $toLong:{$ceil:"$Average"} } } }
])