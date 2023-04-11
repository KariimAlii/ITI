const Counter = require("../Models/CounterSchema");

module.exports = async function (counterId) {
    let sequenceValue;
    let counterData = await Counter.findOne({id:counterId});
    if (!counterData) { //! The First Time
        counterData = new Counter({id:counterId,sequence:1});
        counterData.save();
        sequenceValue=1;
    } else { 
        counterData = await Counter.findOneAndUpdate(
            {id:counterId},
            {$inc : {sequence:1}},
            {new:true},
        )
        sequenceValue = counterData.sequence;
    }
    return sequenceValue;
}

// https://mongoosejs.com/docs/tutorials/findoneandupdate.html
// https://www.mongodb.com/docs/manual/reference/operator/update/inc/
// https://www.mongodb.com/docs/v2.2/tutorial/create-an-auto-incrementing-field/
// https://www.mongodb.com/basics/mongodb-auto-increment
// https://www.tutorialspoint.com/mongodb/mongodb_autoincrement_sequence.htm
// You can use this package instead
// https://www.npmjs.com/package/@typegoose/auto-increment