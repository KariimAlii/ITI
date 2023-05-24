#include <iostream.h>
#include <string.h>
#include <conio.h>
class Person {
protected:
    int id;
    char *name;
public:
    // Constructors
    Person() {id = 0 ; name = new char[20]; name = "abc";};
    Person(int id) {this->id = id; name = new char[20]; name="abc"; };
    Person(int id , char name[]) {this->id = id ; this->name = new char[20] ; strcpy(this->name,name) ;};
    // Getters
    int getID () {return id;};
    char* getName() {return name;};
    // Setters
    void setID (int id) {this->id = id;};
    void setName (char* name) {strcpy(this->name,name);};
};
class Employee : public Person
{
protected:
    int salary;
public:
    // Constructors
    Employee() {salary = 0;};
    Employee(int id , char name[] ,int salary) : Person(id , name) {this->salary = salary;};
    // Getters
    int getSalary() {return salary;};
};
class Customer : public Person
{
protected:
    char *phone;
public:
    // Constructors
    Customer() {phone = NULL;};
    Customer(int id , char name[] ,char phone[]) : Person(id , name) {this->phone = phone;};
    // Getters
    char* getPhone() {return phone;};
};
class Contract : public Employee , public Customer
{
protected:
    int price;
public:
    // Constructors
    Contract() {price = NULL;};
    Contract(int id , char name[] ,int salary , char phone[] , int price) : Employee(id,name,salary) , Customer(id,name,phone) {this->price = price;};
    // Getters
    int getPrice() {return price;};
};
int main() {
    clrscr();
    Customer karim(1,"KarimAli","01222868979");

    cout << "Customer ID: " << karim.getID() <<endl;
    cout << "Customer Name: " << karim.getName() <<endl;
    cout << "Customer Phone: " << karim.getPhone() <<endl;
    cout << "*********************************************"
         << endl;

    Employee Marawan(2,"MarawanAli",2500);
    cout << "Employee ID: " << Marawan.getName() <<endl;
    cout << "Employee Name: " << Marawan.getID() <<endl;
    cout << "Employee Salary: " << Marawan.getSalary() <<endl;
    cout << "*********************************************"
         << endl;

    Contract Car1(3,"Mercedes",3000,"01062065789",7000);
    cout << "Car1 ID: " << Car1.Customer::getID() <<endl;
    cout << "Car1 Name: " << Car1.Employee::getName() <<endl;
    cout << "Car1 Employee Salary: " << Car1.getSalary() <<endl;
    cout << "Car1 Customer Phone: " << Car1.getPhone() <<endl;
    cout << "Car1 Price: " << Car1.getPrice() <<endl;
    getch();
    return 0;
}
