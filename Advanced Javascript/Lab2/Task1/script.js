//! 1. Create your own object that contains a list of numerical
//! sequence, with the following details
// Your constructor takes 3 parameters to define start, end of
// list and step
// The list should be private and filled with private method
// You can create getter and setter for the list if needed
// Allow the user to apply the following functionality to his
// created sequence
// o Append or prepend a new value within the same
// numerical sequence
// o Dequeue or pop a value,
// o you have to ensure that you are pushing value within the
// same sequence otherwise through exception
// o you have to ensure that there is no duplicated value
// otherwise through exception
// you can add any property you need.
console.log("=========Task1=========")
function Queue(start , end , step) {
    this.fillSequenceList = function () {
        let arr = [];
        for (let i = start ; i <= end ; i+=step) arr.push(i);
        return arr;
    }
    this.sequenceList = this.fillSequenceList();
    this.append = function(x) {
        if (x > this.sequenceList[this.sequenceList.length-1] + 2) throw "Out Of Sequence"
        else this.sequenceList.push(x);
    }
    this.prepend = function(x) {
        if (x < this.sequenceList[0] - 2) throw "Out Of Sequence"
        else this.sequenceList.unshift(x)
    }
    this.dequeue = function() {
        this.sequenceList.shift()
    }
    this.pop = function() {
        this.sequenceList.pop()
    }
    this.displaySequence = function() {
        return this.sequenceList;
    }
}

const test = new Queue(0,10,2);
console.log(test.displaySequence())

test.append(12);
console.log(test.displaySequence());

test.prepend(-2);
console.log(test.displaySequence());

test.dequeue();
console.log(test.displaySequence());

test.pop();
console.log(test.displaySequence());

console.log("=========Task2=========")
//=========================================================================
//! 2. Create your box object that contains books objects, ensure that
//! you can
// a. Create book object and add it to box object content
// property
// b. Count # of books inside box
// c. Delete any of these books in box according to book title.
// Note: You should delete a single copy of the books with the
// same title.
//! d. Create Class Property that counts numbers of created books
//! objects and Class method to retrieve it.
// Note:
//  Using of global variables is not allowed
//  No Class methods and properties except for those required
// in part d.

//  Box object has the following properties:
// height, width, length, material, content.
// o The content property contains an array books
//  Book object has the following properties:
// title, numofChapters, author, numofPages, publisher,
// numofCopies

//  you can define any function needed for both box and book
// objects

function Box(height,width,length,material) {
    this.height = height;
    this.width = width;
    this.length = length;
    this.material = material;
    this.content = [];
    this.NumOfBooks = this.content.length;
    this.updateBooksNumber = function () {
        this.NumOfBooks = this.content.length;
    }
    this.addBook = function (newBook) {
        this.content.push(newBook);
        this.updateBooksNumber();
    }
    this.removeBook = function (targetBookTitle) {
        let that = this;
        this.content.forEach(function(book,index) {
            if (book.title === targetBookTitle) {
                if (book.numOfCopies === 1) that.content.splice(index,1);
                else book.numOfCopies--;
                that.updateBooksNumber();
            }
        })
    }
    
    this.countBooks = function() {
        return this.NumOfBooks;
    }
    this.countBookCopies = function (targetBookTitle) {
        let that = this;
        let isFound = false;
        for (let i = 0;i < this.content.length;i++) {
            if (this.content[i].title === targetBookTitle) {
                isFound = true;
                return this.content[i].numOfCopies;
                break;
            }
        }
        if (!isFound) return "Required Book is Not Found!!";
    }
    Box.BoxNum++;
}
Box.BoxNum = 0;
Box.CountBoxNum = function () {
    return this.BoxNum;
}

Box.prototype.valueOf = function () {
    return this.NumOfBooks;
}
function Book(title,numOfChapters,author,numOfPages,publisher,numOfCopies) {
    this.title = title;
    this.numOfChapters = numOfChapters;
    this.author = author;
    this.numOfPages = numOfPages;
    this.publisher = publisher;
    this.numOfCopies = numOfCopies;
}

let harryPotterBook = new Book ('Harry Potter',5,'Mohamed Magdy',145,'Harper Collins',3);
let fancyZonesBook = new Book ('Fancy Zones',4,'Ahmed Yasser',145,'Simon and Schuster',4);
let herculesBook = new Book ('Hercules',7,'Mohamed Moustafa',145,'Macmillan',2);
let batmanBook = new Book ('Batman',9,'Mohanad Shawky',145,'Hachette Book Group',7);
let ancientEgyptBook = new Book ('Ancient Egypt',10,'Karim Ali',145,'Penguin House',5);

let box1 = new Box(70,100,120,'wood');
box1.addBook(harryPotterBook);
console.log("Total Number of Books: " + box1.countBooks());
box1.addBook(fancyZonesBook);
console.log("Total Number of Books: " + box1.countBooks());
box1.addBook(herculesBook);
console.log("Total Number of Books: " + box1.countBooks());
box1.addBook(batmanBook);
console.log("Total Number of Books: " + box1.countBooks());
box1.addBook(ancientEgyptBook);
console.log("Total Number of Books: " + box1.countBooks());

console.log("==============================")

console.log("Total Number of Books: " + box1.countBooks());
console.log("Number of HarryPotter Copies : " + box1.countBookCopies('Harry Potter'));

console.log("==============================")

box1.removeBook('Harry Potter');
console.log("Total Number of Books: " + box1.countBooks());
console.log("Number of HarryPotter Copies : " + box1.countBookCopies('Harry Potter'));

console.log("==============================")

box1.removeBook('Harry Potter');
console.log("Total Number of Books: " + box1.countBooks());
console.log("Number of HarryPotter Copies : " + box1.countBookCopies('Harry Potter'));

console.log("==============================")

box1.removeBook('Harry Potter');
console.log("Total Number of Books: " + box1.countBooks());
console.log("Number of HarryPotter Copies : " + box1.countBookCopies('Harry Potter'));

console.log("==============================")
console.log(Box.CountBoxNum());

let box2 = new Box(70,100,120,'wood');
console.log(Box.CountBoxNum());

box2.addBook(ancientEgyptBook);
console.log("==============================")
console.log(box1.countBooks())
console.log(box2.countBooks())
console.log(box1 + box2);
