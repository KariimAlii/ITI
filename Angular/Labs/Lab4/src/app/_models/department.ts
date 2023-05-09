// export class Department {
//     id : number;
//     deptName : string;
//     location : string;
//     constructor(id:number,deptName:string,location:string)  {
//       this.id = id;
//       this.deptName = deptName;
//       this.location = location;
//     }
// }
export class Department {
  constructor(public id:number = 0,public deptName:string = '',public location:string = '')  {

  }
}
