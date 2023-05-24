#include <iostream.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>

//============== class Student ==================//
class Student
{
    //==========By Default: Private===========//
    int id;
    char *name;

public:
    //======Setters=======//
    void SetID(int reqID);
    void SetName(char N[]);
    //======Getters=======//
    int GetID();
    char *GetName();
    Student();
    //==Destructor==//
    ~Student() { delete (name); };
    //==Copy Constructor==//
    Student(Student &rst);
    //===Equal Operator====//
    Student &operator=(Student &St);
    //==== Operands ====//
    Student operator + (Student St);
    Student operator + (int m);
    friend Student operator+(int m, Student St);
    Student operator+(char n[]);
    friend Student operator+(char n[], Student St);
    Student operator++();
    Student operator++(int d);
    int operator==(Student St);
    operator int();
    operator char*();

};
//============== Non-Member Functions ==================//
Student FillStudent(void);
void PrintStudent(Student S);
Student FindStudentByID(int reqID);
void PrintAll(void);
Student ar[10];
int Size, s;
Student *ptr;
//======================================================================
int main()
{
    clrscr();

    Student st1;
    st1 = FillStudent();

    Student st2;
    st2 = FillStudent();

    //===== +,& =====//
    Student std3;
    std3 = st1 + st2;
    PrintStudent(std3);

    Student std4;
    std4 = std3 + 5;
    PrintStudent(std4);

    Student std5;
    std5 = std4 + "karim";
    PrintStudent(std5);

    Student std6;
    std6 = std5;
    if (std6 == std5) cout <<"Std6 = Std5" <<endl;


    Student std7;
    std7 = std6++;
    PrintStudent(std7);

    Student std8;
    std8 = ++std7;
    PrintStudent(std8);

    cout << (int) std8 <<endl;
    cout << (char*) std8 <<endl;

    getch();
    return 0;
}

// III.Functions

Student FillStudent(void)
{
    Student S;
    int id;
    char n[15];
    cout << "Enter the Student ID";
    cin >> id;
    S.SetID(id);
    cout << "Enter the Student Name";
    cin >> n;
    S.SetName(n);
    return S;
}
Student FindStudentByID(int reqID)
{
    for (int i = 0; i < s; i++)
    {
	if (ptr[i].GetID() == reqID)
	    return ptr[i];
    }
}
void PrintStudent(Student S)
{
    cout << "Student ID: " << S.GetID() << endl;
    cout << "Student Name: " << S.GetName() << endl <<endl;
}
void PrintAll(void)
{
    for (int i = 0; i < s; i++)
    {
	cout << "**************** Student Number " << ptr[i].GetID() << "**********************" << endl;
	cout << "Student ID :    " << ptr[i].GetID() << endl;
	cout << "Student Name :    " << ptr[i].GetName() << endl;
    }
}

Student::Student()
{
    id = 0;
    name = new char['a','b','c','d'];
}
void Student::SetID(int reqID)
{
    id = reqID;
}
void Student::SetName(char N[])
{
    delete (this->name);
    this->name = new char[strlen(N) + 1];
    strcpy(name, N);
}
int Student::GetID()
{
    return id;
}
char *Student::GetName()
{
    return name;
}
Student::Student(Student &rst)
{
    id = rst.id;
    this->name = new char[strlen(rst.name) + 1];
    strcpy(name, rst.name);
}
Student &Student::operator=(Student &St)
{
    id = St.id;
    delete (this->name);
    this->name = new char[strlen(St.name) + 1];
    strcpy(name, St.name);
    return *this;
}

Student Student::operator + (Student St)
{
    Student temp;
    temp.id = id + St.id;
    delete (temp.name);
    temp.name = new char[strlen(this->name) + strlen(St.name) + 1];
    strcpy(temp.name, this->name);
    strcat(temp.name, St.name);
    return temp;
}
Student Student::operator + (int m)
{
    Student temp;
    temp.id = id + m;
    temp.name = new char[strlen(this->name) + 1];
    strcpy(temp.name, this->name);
    return temp;
}
Student Student::operator+(char n[])
{
    Student temp;
    temp.id = this->id;
    temp.name = new char[strlen(this->name) + strlen(n) + 1];
    strcpy(temp.name, this->name);
    strcat(temp.name, n);
    return temp;
}
Student operator+(int m, Student St)
{ // friend
    Student temp;
    temp.id = m + St.id;
    temp.name = new char[strlen(St.name) + 1];
    strcpy(temp.name, St.name);
    return temp;
}

Student operator+(char n[], Student St)
{ // friend
    Student temp;
    temp.id = St.id;
    temp.name = new char[strlen(n) + strlen(St.name) + 1];
    strcpy(temp.name, n);
    strcat(temp.name, St.name);
    return temp;
}
Student Student::operator++()
{ // preIncrement
    id++;
    return *this;
}
Student Student::operator++(int d)
{ // postIncrement
    Student old;
    old = *this;
    id++;
    return old;
}
int Student::operator==(Student St)
{
    return (id == St.id && !strcmp(name, St.name));
}

Student::operator int()
{
    return id;

}

Student::operator char*()
{
    return name;
}
