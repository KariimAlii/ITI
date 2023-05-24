#include <iostream>
using namespace std;
class Person
{
protected:
    int id;
public:
    Person () {}
    Person (int i) {id = i;}
    Person (Person& p) {id = p.id;}
    int GetId() {return id;}
    void SetId(int m) {id = m;}
};
class Employee : public Person
{
    int salary;
public:
    Employee(int i , int s) : Person(i)
    {
        salary = s;
    }
    Employee (Employee& e)
    {
        salary = e.salary;
    }
    int GetSalary() {return salary;}
    void SetSalary(int m ) {salary = m;}
};
Employee FillEmp()
{
    Employee em(3,4);
    return em;
}
int main() {
//========25==========//
Employee emp(7,8);
emp = FillEmp();
cout << emp.GetId();
cout << emp.GetSalary() <<endl;
}

//========16==========//
//int a = 5;
//int b = 10;
//int c = 15;
//int *arr[] = {&a,&b,&c};
//cout << arr[1];
//========17==========//
//char* ptr;
//char Str[] = "abcdefg";
//ptr = Str;
//ptr+=5;
//cout << ptr;

//========18==========//
//int result (int n) {
//    if (n == 1) return 2;
//    else return (2 * result (n-1) );
//}
//int main() {
//    cout << result(5);
//    return 0;
//}


//========19==========//
//class Test {
//public:
//    int x;
//    Test (int y) {x = y++ ;};
//    Test (Test& r) {x = ++r.x ;};
//    void print() {cout << x ;};
//};
//int main() {
//    Test t(1);
//    t.print();
//    Test x(t);
//    x.print();
//    t.print();
//    return 0;
//}

//========20==========//
//int a[2][4] = {3,6,9,12,15,18,21,24};
//cout << *(a[1]+2)
//<< *( *(a+1)+2 )
//<< 2[ 1[a] ];

//    int a[2][4] = {3,6,9,12,15,18,21,24};
//    cout << *(a[1]+2)
//         << *( *(a+1)+2 )
//         << 2[ 1[a] ];

//========7==========//
//class A {
//    float d;
//public:
//    virtual void func() {cout << "Hello this is class A\n";}
//};
//class B : public A {
//    int a = 15;
//public:
//    void func() {cout << "Hello this is class B\n";}
//};
//int main() {
//
//    A* a;
//    a->func();
//    return 0;
//}

//========25==========//
//int f (int& x , int c)
//{
//    c = c-1;
//    if (c==0) return 1;
//    x = x+1;
//    return f(x,c) * x;
//}
//int main() {
//
//    int a = 4;
//    int b = f(a,a);
//    cout << b;
//    return 0;
//}