#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
#include "myconfig.h"
#define yAddNode 1
#define ySearchByID 2
#define ySearchByName 3
#define yDeleteById 4
#define yFreeList 5
#define yInsertByLoc 6
#define yUpdateById 7
#define yListAllStudents 8
#define yFindLength 9
#define yExit 10

#define ArrowUp 72
#define ArrowDown 80
#define Enter 13
#define Escape 27
#define Home 71
#define End 79
//================ Functions Prototype =================//
void PrintMenu(int x);
void findColor(int y);

//============== Double Linked List ==================//
struct Student
{
    int id;
    char name[20];
    int grades[3];
};
struct Node
{
    struct Student std;
    struct Node *pPrev;
    struct Node *pNext;
};
struct Node *pHead; // =NULL
struct Node *pTail; // =NULL
int AddNode(void);
int InsertNode(void);
struct Node *CreateNode(struct Student newStd);
struct Node *SearchNode(int reqId);
int DeleteNode(void);
void FreeList(void);
void RearrangeNodes(void);
void ListAllNodes(void);

struct Student InsertStudentInfo(void);
void PrintNode(void);
struct Node *SearchNodeByName(char name[]);
void PrintNodeByName(void);
void UpdateNode(void);
int Length = 0;
//======================================================================

int main()
{
    // I. Variables Declaration

    int x = 1, y, a, b, result, App = 1;
    
    char Ascii;
    struct Student std;
    
    // II.Expressions & Function Calling
    myconfig();
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
            if (y == yAddNode)
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
                y = yAddNode;
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
            case yAddNode:
                clrscr();
                AddNode();
                getch();
                clrscr();
                break;
            case ySearchByID:
                clrscr();
                PrintNode();
                getch();
                clrscr();
                break;
            case ySearchByName:
                clrscr();
                PrintNodeByName();
                getch();
                clrscr();
                break;
            case yDeleteById:
                clrscr();
                DeleteNode();
                getch();
                clrscr();
                break;
            case yFreeList:
                clrscr();
                FreeList();
                getch();
                clrscr();
                break;
            case yInsertByLoc:
                clrscr();
                InsertNode();
                getch();
                clrscr();
                break;
            case yUpdateById:
                clrscr();
                UpdateNode();
                getch();
                clrscr();
                break;
            case yListAllStudents:
                clrscr();
                ListAllNodes();
                getch();
                clrscr();
                break;
            case yFindLength :
                clrscr();
                Length = FindLengthRecursion(pHead);
                printf("The Length = %d ",Length);
                getch();
                clrscr();
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
            y = yAddNode;
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
    gotoxy(x, yAddNode);
    _cprintf("1.Add a new Student");
    gotoxy(x, ySearchByID);
    _cprintf("2.Search for a Student By his ID");
    gotoxy(x, ySearchByName);
    _cprintf("3.Search for a Student By his Name");
    gotoxy(x, yDeleteById);
    _cprintf("4.Delete a Student By his ID");
    gotoxy(x, yFreeList);
    _cprintf("5.Delete All Students");
    gotoxy(x, yInsertByLoc);
    _cprintf("6.Insert a new Student by His Location");
    gotoxy(x, yUpdateById);
    _cprintf("7.Update a Student info by his ID");
    gotoxy(x, yListAllStudents);
    _cprintf("8.List All Students");
    gotoxy(x, yFindLength);
    _cprintf("9.FindLength");
    gotoxy(x, yExit);
    _cprintf("9.Exit");
}

void findColor(int y)
{
    textcolor(RED);
    textbackground(WHITE);
    switch (y)
    {
    case yAddNode:
        _cprintf("1.Add a new Student");
        break;
    case ySearchByID:
        _cprintf("2.Search for a Student By his ID");
        break;
    case ySearchByName:
        _cprintf("3.Search for a Student By his Name");
        break;
    case yDeleteById:
        _cprintf("4.Delete a Student By his ID");
        break;
    case yFreeList:
        _cprintf("5.Delete All Students");
        break;
    case yInsertByLoc:
        _cprintf("6.Insert a new Student by His Location");
        break;
    case yUpdateById:
        _cprintf("7.Update a Student info by his ID");
        break;
    case yListAllStudents:
        _cprintf("8.List All Students");
        break;
    case yFindLength:
        _cprintf("9.FindLength");
        break;
    case yExit:
        _cprintf("10.Exit");
        break;
    }
}
struct Student InsertStudentInfo(void)
{
    int j = 0;
    struct Student std;
    printf("Insert Your Student ID:   ");
    scanf("%d", &std.id);
    printf("Insert Your Student Name:   ");
    scanf("%s", std.name);
    printf("***********************Student Grades******************");
    for (j = 0; j < 3; j++)
    {
        printf("\nGrade of subject(%d)      ", j + 1);
        scanf("%d", &std.grades[j]);
    }
    return std;
}
struct Node *CreateNode(struct Student newStd)
{
    struct Node *ptr;
    ptr = (struct Node *)malloc(sizeof(struct Node));
    if (ptr)
    { // !=NULL
        ptr->std = newStd;
        ptr->pNext = ptr->pPrev = NULL;
    }
    return ptr;
}
int AddNode(void)
{
    int retval = 0;
    struct Student newStd;
    struct Node *pCur;

    newStd = InsertStudentInfo();
    pCur = CreateNode(newStd);
    if (pCur)
    { // = address ( Dynamic ALlocation Success ) (Node Created successfully)
        retval = 1;
        if (pHead == NULL)
        { // No List
            pHead = pCur;
            pTail = pCur;
        }
        else
        {
            pTail->pNext = pCur;
            pCur->pPrev = pTail;
            pTail = pCur;
        }
    }
    return retval;
}
struct Node *SearchNode(int reqId)
{
    struct Node *ptr;
    ptr = pHead;
    while (ptr->std.id != reqId && ptr != NULL)
    {
        ptr = ptr->pNext;
    }
    if (ptr == NULL)
        printf("No Student Found by this ID!");
    return ptr;
}
struct Node *SearchNodeByName(char name[])
{
    struct Node *ptr;
    ptr = pHead;
    // strcmp :: equal => Z  , Notequal => N.Z
    //  while (ptr -> std.name != name && ptr != NULL) {
    while (strcmp(ptr->std.name, name) && ptr != NULL)
    {
        ptr = ptr->pNext;
    }
    if (ptr == NULL)
        printf("No Student Found by this Name!");
    return ptr;
}
void FreeList(void)
{
    struct Node *ptr;
    while (pHead)
    { // (pHead != NULL)
        ptr = pHead;
        pHead = pHead->pNext;
        free(ptr);
    }
    pTail = NULL;
    printf("Your Students are Deleted !!");
}
int InsertNode(void)
{
    struct Student newStd;
    struct Node *temp, *ptr;
    int retval = 0, i, loc;
    printf("Insert Required Location :   ");
    scanf("%d", &loc);
    newStd = InsertStudentInfo();
    ptr = CreateNode(newStd);
    if (ptr)
    { // New Node created successfully
        retval = 1;
        if (pHead == NULL)
        { // No List
            pHead = pTail = ptr;
        }
        else
        {
            if (loc == 0)
            { // First Node
                ptr->pNext = pHead;
                pHead->pPrev = ptr;
                pHead = ptr;
            }
            else
            { // Middle or Last
                temp = pHead;
                for (i = 0; i < loc - 1 && temp; i++)
                    temp = temp->pNext;
                if (temp == pTail || temp == NULL)
                { // last
                    pTail->pNext = ptr;
                    ptr->pPrev = pTail;
                    pTail = ptr;
                }
                else
                { // middle
                    (temp->pNext)->pPrev = ptr;
                    ptr->pNext = temp->pNext;
                    ptr->pPrev = temp;
                    temp->pNext = ptr;
                }
            }
        }
    }

    return retval;
}
int DeleteNode(void)
{

    struct Node *ptr;
    int retval = 0, i, id;

    printf("Enter The Required Student ID");
    scanf("%d", &id);
    ptr = SearchNode(id);
    if (ptr)
    { // New Node created successfully
        retval = 1;
        if (id == 0)
        { // First Node
            (ptr->pNext)->pPrev = NULL;
            pHead = ptr->pNext;
            ptr->pNext = NULL;
            free(ptr);
        }
        else
        { // Middle or Last
            if (ptr == pTail)
            { // last
                pTail = ptr->pPrev;
                (ptr->pPrev)->pNext = NULL;
                ptr->pPrev = NULL;
                free(ptr);
            }
            else
            { // middle
                (ptr->pPrev)->pNext = ptr->pNext;
                (ptr->pNext)->pPrev = ptr->pPrev;
                ptr->pNext = ptr->pPrev = NULL;
                free(ptr);
            }
        }
    }

    return retval;
}
void RearrangeNodes(void)
{
    int i;
    struct Node *temp;
    temp = pHead;
    for (i = 0; temp; i++)
    {
        temp->std.id = i;
        temp = temp->pNext;
    }
}
void ListAllNodes(void)
{
    int i, j;
    struct Node *temp;
    temp = pHead;
    for (i = 0; temp; i++)
    {
        printf("***************** Student Num %d ******************\n", i);
        printf("Student ID : %d\n", temp->std.id);
        printf("Student Name : %s\n", temp->std.name);
        // temp = temp -> pNext;
        for (j = 0; j < 3; j++)
            printf("Grade of subject(%d) : %d\n", j + 1, temp->std.grades[j]);
        temp = temp->pNext;
    }
}
void PrintNode(void)
{
    struct Node *ptr;
    int reqID, j;
    printf("Enter The Required Student ID:   ");
    scanf("%d", &reqID);
    ptr = SearchNode(reqID);
    if (ptr)
    {
        printf("\n***************** Student Num %d ******************\n", ptr->std.id);
        printf("\nStudent ID : %d\n", ptr->std.id);
        printf("\nStudent Name : %s\n", ptr->std.name);
        for (j = 0; j < 3; j++)
            printf("Grade of subject(%d) : %d\n", j + 1, ptr->std.grades[j]);
    }
}
void PrintNodeByName(void)
{
    int j;
    struct Node *ptr;
    char reqName[20];
    printf("Enter The Required Student Name:   ");
    scanf("%s", reqName);
    ptr = SearchNodeByName(reqName);
    if (ptr)
    {
        printf("\n***************** Student Num %d ******************\n", ptr->std.id);
        printf("\nStudent ID : %d\n", ptr->std.id);
        printf("\nStudent Name : %s\n", ptr->std.name);
        for (j = 0; j < 3; j++)
            printf("Grade of subject(%d) : %d\n", j + 1, ptr->std.grades[j]);
    }
}
void UpdateNode(void)
{
    int reqID, j;
    struct Node *ptr;
    printf("Enter the Required Student ID:     ");
    scanf("%d", &reqID);
    ptr = SearchNode(reqID);
    if (ptr)
    {
        printf("Current Student ID : %d\n", ptr->std.id);
        printf("Enter the new ID :  ");
        scanf("%d", &ptr->std.id);

        printf("Current Student Name : %s\n", ptr->std.name);
        printf("Enter the new Name :  ");
        scanf("%s", ptr->std.name);

        for (j = 0; j < 3; j++)
        {
            printf("\nGrade of subject(%d) : %d  ", j + 1, ptr->std.grades[j]);
            printf("Enter the new Grade :  ");
            scanf("%d", &ptr->std.grades[j]);
        }

        printf("\n***************** Student Num %d After Update ******************\n", ptr->std.id);
        printf("\nStudent ID : %d\n", ptr->std.id);
        printf("\nStudent Name : %s\n", ptr->std.name);
        for (j = 0; j < 3; j++)
            printf("Grade of subject(%d) : %d\n", j + 1, ptr->std.grades[j]);
    }
}
int FindLengthRecursion(struct Node *pHead)
{
    struct Node* ptr = pHead;
    if (pHead)
    {
        while (ptr -> pNext != NULL)
        {
            ptr = ptr->pNext;
            Length++;
            FindLengthRecursion(ptr);
        }
    }
    return Length;
}
int FindLengthIterative(struct Node *pHead)
{
    struct Node* ptr;
    if (pHead) {
        ptr = pHead;
        while (ptr != NULL) {
            Length++;
            ptr = ptr -> pNext;
        }
    }
    return Length;
}