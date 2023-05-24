#include <iostream>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
#include "myconfig.h"
using namespace std;
#define yAddStudent 1
#define yPrintStudentByID 2
#define ygetCount 3
#define ysetSchoolName 4
#define ygetSchoolName 5
#define yPrintAll 6
#define yExit 7

#define ArrowUp 72
#define ArrowDown 80
#define Enter 13
#define Escape 27
#define Home 71
#define End 79

//================ Functions Prototype =================//
void PrintMenu(int x);
void findColor(int y);
void redraw(int x, int y);
//============== class Student ==================//
class Student
{
    //==========By Default: Private===========//
    int id;
    char *name;
    static int count;
    static char schoolName[20];

public:
    //======Setters=======//
    void SetID(int reqID);
    void SetName(char N[]);
    //======Getters=======//
    int GetID();
    char *GetName();
    Student();
    //==Destructor==//
    ~Student() { 
        delete (name); 
        count--;
    };
    //==Copy Constructor==//
    Student(Student &rst);
    //===Equal Operator====//
    Student &operator=(const Student &St);
    //===Static Methods====//
    static int GetCount();
    static void SetSchoolName(char n[]);
    static char* getSchoolName();
};
int Student::count = 0;
char Student::schoolName[] = {'a' , 'b' , 'c'};
//============== Non-Member Functions ==================//
Student FillStudent(void);
void PrintStudent(Student S);
Student FindStudentByID(int reqID);
void PrintAll(void);

int Size, s;
Student *ptr;
//======================================================================
int main()
{
    // I. Variables Declaration

    int x = 1, y, App = 1, d, id;
    char Ascii;
    
    // II.Expressions & Function Calling
    myconfig();
    clrscr();
    cout << "Enter The Required Number of Students   ";
    cin >> Size;
    ptr = new Student[Size];
    clrscr();
    PrintMenu(x);
    y = 1;
    gotoxy(x, y);
    findColor(y);
    while (App != 0)
    {

        Ascii = getch(); // Normal Key
        if (Ascii == 0)
            Ascii = getch(); // Extended Key
        switch (Ascii)
        {
        case ArrowUp:
            if (y == yAddStudent)
            {
                y = yExit;
                redraw(x, y);
            }
            else
            {
                y--;
                redraw(x, y);
            }
            break;
        case ArrowDown:
            if (y == yExit)
            {
                y = yAddStudent;
                redraw(x, y);
            }
            else
            {
                y++;
                redraw(x, y);
            }
            break;
        case Enter:
            switch (y)
            {
            case yAddStudent:
                clrscr();
                ptr[s] = FillStudent();
                s++;
                clrscr();
                redraw(x, y);
                break;
            case yPrintStudentByID:
                clrscr();
                cout << "Enter The Required Student ID:   ";
                cin >> id;
                PrintStudent(FindStudentByID(id));
                getch();
                clrscr();
                redraw(x, y);
                break;
            case ygetCount:
                clrscr();
                cout << "The Students Number is: " 
                     << Student::GetCount() 
                     << endl;
                getch();
                clrscr();
                redraw(x, y);
                break;
            case ysetSchoolName:
                clrscr();
                char schoolName[20];
                cout << "Enter The School Name    " ;
                cin >> schoolName;
                Student::SetSchoolName(schoolName);
                getch();
                clrscr();
                redraw(x, y);
                break;
            case ygetSchoolName:
                clrscr();
                cout << "School Name : " 
                     << Student::getSchoolName() 
                     <<endl;
                getch();
                clrscr();
                redraw(x, y);
                break;
            case yPrintAll:
                clrscr();
                PrintAll();
                getch();
                clrscr();
                redraw(x, y);
                break;
            case yExit:
                App = 0;
                break;
            }
            break;
        case Escape:
            App = 0;
            break;
        case Home:
            y = yAddStudent;
            redraw(x, y);
            break;
        case End:
            y = yExit;
            redraw(x, y);
            break;
        }
    }
    if (Ascii != Escape && !(Ascii == Enter && y == yExit))
        getch();
    clrscr();
    delete []ptr;
    return 0;
}


void PrintMenu(int x)
{
    textcolor(WHITE);
    textbackground(BLACK);
    gotoxy(x, yAddStudent);
    _cprintf("1.Add a New Student");
    gotoxy(x, yPrintStudentByID);
    _cprintf("2.Student Info By ID");
    gotoxy(x, ygetCount);
    _cprintf("3.Number of Students");
    gotoxy(x, ysetSchoolName);
    _cprintf("4.Set the School Name");
    gotoxy(x, ygetSchoolName);
    _cprintf("5.Print the School Name");
    gotoxy(x, yPrintAll);
    _cprintf("6.Print All Students");
    gotoxy(x, yExit);
    _cprintf("7.Exit");
}

void findColor(int y)
{
    textcolor(RED);
    textbackground(WHITE);
    switch (y)
    {
    case yAddStudent:
        _cprintf("1.Add a New Student");
        break;
    case yPrintStudentByID:
        _cprintf("2.Student Info By ID");
        break;
    case ygetCount:
        _cprintf("3.Number of Students");
        break;
    case ysetSchoolName:
        _cprintf("4.Set the School Name");
        break;
    case ygetSchoolName:
        _cprintf("5.Print the School Name");
        break;
    case yPrintAll:
        _cprintf("6.Print All Students");
        break;
    case yExit:
        _cprintf("7.Exit");
        break;
    }
}
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
    cout << "Student Name: " << S.GetName() << endl;
    cout << "The School Name: " 
         << Student::getSchoolName()
         <<endl;
}
void PrintAll(void)
{
    for (int i = 0; i < s; i++)
    {
        cout << "**************** Student Number " 
             << ptr[i].GetID() 
             << "**********************" 
             << endl;
        cout << "Student ID :    " 
             << ptr[i].GetID() 
             << endl;
        cout << "Student Name :    " 
             << ptr[i].GetName() 
             << endl;
        cout << "The School Name: " 
             << Student::getSchoolName()
             <<endl;
    }

}
void redraw(int x, int y)
{
    PrintMenu(x);
    gotoxy(x, y);
    findColor(y);
}
Student::Student()
{
    id = 0;
    name = new char['a','b','c'];
    count++;
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
    count++;
}
Student &Student::operator=(const Student &St)
{
    id = St.id;
    delete (this->name);
    this->name = new char[strlen(St.name) + 1];
    strcpy(name, St.name);
    return *this;
}
int Student::GetCount() {
    return Student::count;
}
void Student::SetSchoolName(char n[]) {
    strcpy(Student::schoolName,n);
}
char* Student::getSchoolName() {
    return Student::schoolName;
}