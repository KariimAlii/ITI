#include <iostream>
#include "myconfig.h"
using namespace std;

#define yAddStudent 1
#define yPrintStudentByID 2
#define yPrintAll 3
#define yExit 4

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
//============== Binary Search Tree ==================//
struct Student
{
    int id;
    char name[20];
};
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
    // I. Variables Declaration

    int x = 1, y, App = 1, d, id;
    char Ascii;

    myconfig();
    // II.Expressions & Function Calling
    clrscr();
    cout << "Enter The Required Number of Students   ";
    cin >> Size;
    ptr = (Student *)malloc(Size * sizeof(Student));
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
                PrintMenu(x);
                gotoxy(x, y);
                findColor(y);
            }
            else
            {
                y--;
                PrintMenu(x);
                gotoxy(x, y);
                findColor(y);
            }
            break;
        case ArrowDown:
            if (y == yExit)
            {
                y = yAddStudent;
                PrintMenu(x);
                gotoxy(x, y);
                findColor(y);
            }
            else
            {
                y++;
                PrintMenu(x);
                gotoxy(x, y);
                findColor(y);
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
            PrintMenu(x);
            gotoxy(x, y);
            findColor(y);
            break;
        case End:
            y = yExit;
            PrintMenu(x);
            gotoxy(x, y);
            findColor(y);
            break;
        }
    }
    if (Ascii != Escape && !(Ascii == Enter && y == yExit))
        getch();
    return 0;
}

// III.Functions

void PrintMenu(int x)
{
    textcolor(WHITE);
    textbackground(BLACK);
    gotoxy(x, yAddStudent);
    _cprintf("1.Add a New Student");
    gotoxy(x, yPrintStudentByID);
    _cprintf("2.Student Info By ID");
    gotoxy(x, yPrintAll);
    _cprintf("3.Print All Students");
    gotoxy(x, yExit);
    _cprintf("4.Exit");
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
    case yPrintAll:
        _cprintf("3.Print All Students");
        break;
    case yExit:
        _cprintf("4.Exit");
        break;
    }
}
Student FillStudent(void)
{
    Student S;
    cout << "Enter the Student ID";
    cin >> S.id;
    cout << "Enter the Student Name";
    cin >> S.name;
    return S;
}
Student FindStudentByID(int reqID)
{
    for (int i = 0; i < s; i++)
    {
        if (ptr[i].id == reqID)
            return ptr[i];
    }
}
void PrintStudent(Student S)
{
    cout << "Student ID: " << S.id << endl;
    cout << "Student Name: " << S.name << endl;
}
void PrintAll(void)
{
    for (int i = 0; i < s; i++)
    {
        cout << "**************** Student Number " << ptr[i].id << "**********************" << endl;
        cout << "Student ID :    " << ptr[i].id << endl;
        cout << "Student Name :    " << ptr[i].name << endl;
    }
}
void redraw(int x, int y)
{
    PrintMenu(x);
    gotoxy(x, y);
    findColor(y);
}
