// export class Student {
//   id : number;
//   name : string;
//   age : number;
//   deptNo : number;
//   constructor (id:number = 0,name:string = "",age:number = 15,deptNo:number = 4) {
//     this.id = id;
//     this.name = name;
//     this.age = age;
//     this.deptNo = deptNo;
//   }
// }

export class Student {

  constructor (public id:number = 0,public name:string = "",public age:number = 15,public deptNo:number = 4) {

  }
}