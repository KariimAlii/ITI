// REFERENCE : https://www.javatpoint.com/array-representation-of-queue
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
#include "myconfig.h"

#define yInQueue 1
#define yDeQueue 2
#define yFreeList 3
#define yListAllStudents 4
#define yExit 5

#define ArrowUp 72
#define ArrowDown 80
#define Enter 13
#define Escape 27
#define Home 71
#define End 79
//================ Functions Prototype =================//
void PrintMenu(int x);
void findColor(int y);

//============== Forward Linked List ==================//

struct Student
{
    int id ;
    char name[20];
    int grades[3];
};
struct Node
{
    struct Student std;
};
int eoq; // global variable initialized with 0
int soq; // global variable initialized with 0
struct Node ar[100];

void FreeList(void);
void ListAllNodes (void);

struct Student InsertStudentInfo (void);
struct Node CreateNode(struct Student newStd);


//======================================================================
//================ Queue with Array =================//
int InQueue (struct Node newNode);
struct Node DeQueue (void);
void PrintNodeForDeQueue (struct Node reqNode);

//======================================================================
int main ()
{
// I. Variables Declaration

	int x = 1 , y   , App = 1 , isOk ;
	char Ascii;

	struct Student newStd;
    struct Node newNode ;

    myconfig();
// II.Expressions & Function Calling
	clrscr();

	PrintMenu(x);
	y = 1;
	gotoxy(x,y);
	findColor(y);
	while (App != 0)
	{

		Ascii = getch(); // Normal Key
		if (Ascii == 0) Ascii = getch(); // Extended Key
		switch (Ascii)
		{
			case ArrowUp:
				if (y == yInQueue)
				{
					y = yExit;
					PrintMenu(x);
					gotoxy(x,y);
					findColor(y);
				}
				else
				{
					y--;
					PrintMenu(x);
					gotoxy(x,y);
					findColor(y);
				}
				break;
			case ArrowDown:
				if (y == yExit)
				{
					y = yInQueue;
					PrintMenu(x);
					gotoxy(x,y);
					findColor(y);
				}
				else
				{
					y++;
					PrintMenu(x);
					gotoxy(x,y);
					findColor(y);
				}
				break;
			case Enter:
				switch (y)
				{
					case yInQueue:
						clrscr();
						newStd = InsertStudentInfo();
    					newNode = CreateNode(newStd);
						isOk = InQueue(newNode);
						if (isOk) {
							printf("New Student Added Successfully!");
						} else {
							printf("Sorry , Can't add a new Student right now!");
						}
						getch();
						clrscr();
						break;
					case yDeQueue :
					    clrscr();
						PrintNodeForDeQueue(DeQueue());
						getch();
						clrscr();
						break;
					case yFreeList:
						clrscr();
						FreeList();
						printf("All Students Deleted !!");
						getch();
						clrscr();
						break;
					case yListAllStudents:
						clrscr();
						ListAllNodes();
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
				y = yInQueue;
				PrintMenu(x);
				gotoxy(x,y);
				findColor(y);
				break;
			case End:
				y = yExit;
				PrintMenu(x);
				gotoxy(x,y);
				findColor(y);
				break;
			}
	}
if (Ascii != Escape && !(Ascii == Enter && y == yExit)) getch();
return 0;
}

// III.Functions

void PrintMenu(int x)
{
	textcolor(WHITE);
	textbackground(BLACK);
	gotoxy(x,yInQueue);
	_cprintf("1.Add a new Student");
	gotoxy(x,yDeQueue);
	_cprintf("2.Get the First Student Out");

	gotoxy(x,yFreeList);
	_cprintf("3.Delete All Students");

	gotoxy(x,yListAllStudents);
	_cprintf("4.List All Students");
	gotoxy(x,yExit);
	_cprintf("5.Exit");
}

void findColor(int y) {
	textcolor(RED);
	textbackground(WHITE);
	switch (y)
				{
					case yInQueue:
						_cprintf("1.Add a new Student");
						break;
                    case yDeQueue:
						_cprintf("2.Get the First Student Out");
						break;
					case yFreeList:
						_cprintf("3.Delete All Students");
						break;
					case yListAllStudents:
						_cprintf("4.List All Students");
						break;
					case yExit:
						_cprintf("5.Exit");
						break;
				}
}
struct Student InsertStudentInfo (void) {
	int j = 0;
	struct Student std;
	printf("Insert Your Student ID:   ");
	scanf("%d",&std.id);
	printf("Insert Your Student Name:   ");
	scanf("%s",std.name);
	printf("***********************Student Grades******************");
	for (j=0 ; j< 3 ; j++) {
		printf("\nGrade of subject(%d)      ", j+1 );
		scanf("%d",&std.grades[j]);
	}
	return std;
}
struct Node CreateNode(struct Student newStd) {
    struct Node newNode;
    newNode.std = newStd;
    return newNode;
}
int InQueue (struct Node newNode) {
    int retval = 0;
    if (eoq < 100) {
        ar[eoq] = newNode;
        eoq++;
        retval = 1;
    }
    return retval;
}
struct Node DeQueue (void) {
	struct Node reqNode;
	if (eoq != 0) {
		reqNode = ar[soq];
		soq++;
		return reqNode;
	}
}
void PrintNodeForDeQueue (struct Node reqNode) {
	int j;
	printf("\n***************** Student Num %d ******************\n",reqNode.std.id);
	printf("\nStudent ID : %d\n", reqNode.std.id);
	printf("\nStudent Name : %s\n", reqNode.std.name);
	for (j=0 ; j< 3 ; j++) printf("Grade of subject(%d) : %d\n", j+1 ,reqNode.std.grades[j]);
}

void FreeList(void) {
	while (soq <= eoq) soq++;
}

void ListAllNodes (void) {
	int i , j;
	for (i = soq ; i < eoq ; i++) {
		printf("***************** Student Num %d ******************\n",i+1);
		printf("Student ID : %d\n",ar[i].std.id);
		printf("Student Name : %s\n",ar[i].std.name);
		for (j=0 ; j< 3 ; j++) printf("Grade of subject(%d) : %d\n", j+1 ,ar[i].std.grades[j]);
	}
}

