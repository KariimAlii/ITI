#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
#include "myconfig.h"

#define yAddNode 1
#define yPop 2
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
    struct Node* pNext;
};
struct Node* pHead; // =NULL
struct Node* pTail; // =NULL

int AddNode (void);
int InsertNode (void);
struct Node* CreateNode(struct Student newStd);


void FreeList(void);

void ListAllNodes (void);

struct Student InsertStudentInfo (void);


//======================================================================
//================ Stack with Linked List =================//
int Push (struct Node* pCur);
struct Node Pop (void);
void PrintNodeForPop (struct Node reqNode);

//======================================================================
int main ()
{
// I. Variables Declaration

	int x = 1 , y   , App = 1 , isOk ;
	char Ascii;

	struct Student newStd;
    struct Node* ptr ;

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
				if (y == yAddNode)
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
					y = yAddNode;
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
					case yAddNode:
						clrscr();
						newStd = InsertStudentInfo();
    					ptr = CreateNode(newStd);
						isOk = Push(ptr);
						if (isOk) {
							printf("New Student Added Successfully!");
						} else {
							printf("Sorry , Can't add a new Student right now!");
						}
						// Push(ptr);
						getch();
						clrscr();
						break;
					case yPop :
					    clrscr();
						PrintNodeForPop(Pop());
						getch();
						clrscr();
						break;
					case yFreeList:
						clrscr();
						FreeList();
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
				y = yAddNode;
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
	gotoxy(x,yAddNode);
	_cprintf("1.Add a new Student");
	gotoxy(x,yPop);
	_cprintf("2.Pop a Student");

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
					case yAddNode:
						_cprintf("1.Add a new Student");
						break;
                    case yPop:
						_cprintf("2.Pop a Student");
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
struct Node* CreateNode(struct Student newStd) {
    struct Node* ptr;
    ptr = (struct Node *) malloc( sizeof(struct Node) );
    if (ptr) {    // !=NULL
	ptr -> std = newStd ;
	ptr -> pNext = NULL ;
    }
    return ptr;
}
int Push (struct Node* pCur) {
    int retval = 0;
    if (pCur) { // = address ( Dynamic ALlocation Success ) (Node Created successfully)
		retval = 1;
		if (pHead == NULL) {    // No List
	    	pHead = pCur;
	    	pTail = pCur;
		}
		else {
	    	pTail -> pNext = pCur;
	    	pTail = pCur;
		}
    }
    return retval;
}
struct Node Pop (void) {
	struct Node* ptr = NULL; // if there is no list
	if (pHead) {    // There is a list
		ptr = pHead;
		if (pHead == pTail) {
            pHead = pTail = NULL;
		}
		while (ptr -> pNext != NULL) { // now pointer is pointing to the last node  or while (ptr != pTail)
            if ((ptr -> pNext) -> pNext == NULL) pTail = ptr;
			ptr = ptr -> pNext;
			pTail -> pNext = NULL;
		}
	}
	return *ptr;
}
void PrintNodeForPop (struct Node reqNode) {
	int j;
	printf("\n***************** Student Num %d ******************\n",reqNode.std.id);
	printf("\nStudent ID : %d\n", reqNode.std.id);
	printf("\nStudent Name : %s\n", reqNode.std.name);
	for (j=0 ; j< 3 ; j++) printf("Grade of subject(%d) : %d\n", j+1 ,reqNode.std.grades[j]);
}

void FreeList(void) {
	struct Node* ptr;
	while (pHead) {   // (pHead != NULL)
		ptr = pHead;
		pHead = pHead -> pNext;
		free(ptr);
	}
	pTail = NULL;
	printf("Your Students are Deleted !!");
}

void ListAllNodes (void) {
	int i , j;
	struct Node *temp;
	temp = pHead;
	for (i = 0 ; temp ; i++) {
		printf("***************** Student Num %d ******************\n",i);
		printf("Student ID : %d\n", temp -> std.id);
		printf("Student Name : %s\n", temp -> std.name);
		// temp = temp -> pNext;
		for (j=0 ; j< 3 ; j++) printf("Grade of subject(%d) : %d\n", j+1 ,temp -> std.grades[j]);
		temp = temp -> pNext;
	}
}



