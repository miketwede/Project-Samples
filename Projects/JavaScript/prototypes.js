var myFather = new Person("John", "Doe", 50, "blue");
var myMother = new Person("Sally", "Rally", 48, "green");

console.log(myFather);
console.log(myFather.name());

console.log(myMother);
console.log(myMother.name());


function Person(first, last, age, eyecolor) {
    this.firstName = first;
    this.lastName = last;
    this.age = age;
    this.eyeColor = eyecolor;
    this.nationality = "English"; // read only property
    this.name = function() {return this.firstName + " " + this.lastName;}; // method
}