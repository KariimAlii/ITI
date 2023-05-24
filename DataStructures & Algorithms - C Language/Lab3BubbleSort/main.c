#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
#include "myconfig.h"

#define yAddStudent 1
#define yBubbleSort 2
#define yModifiedBubbleSort 3
#define yMergeSort 4
#define yFreeList 5
#define yPrintStudentByID 6
#define yListAllStudents 7
#define yExit 8

#define ArrowUp 72
#define ArrowDown 80
#define Enter 13
#define Escape 27
#define Home 71
#define End 79
//================ Functions Prototype =================//
void PrintMenu(int x);
void findColor(int y);

//============== Array to Sort ==================//

struct Student
{
    int id ;
    char name[20];
    int grades[3];
};

int Size = 0 , start = 0 , end = 0;
struct Student ar[20];

void FreeList(void);
void ListAllNodes (void);

struct Student InsertStudentInfo (void);
struct Node CreateNode(struct Student newStd);
//============== BubbleSort ==================//
void BubbleSort (void);
//============== Modified Bubble Sort ==================//
void ModifiedBubbleSort (void);
//============== Merge Sort ==================//
void MergeSort(int LB , int UB);
void Merge (int low , int middle , int high);
//======================================================================
void AddStudent (struct Student newStd);
void PrintStudentById (int reqID);
//======================================================================
int main ()
{
// I. Variables Declaration

	int x = 1 , y   , App = 1 , ID ;
	char Ascii;



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
				if (y == yAddStudent)
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
					y = yAddStudent;
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
                    case yAddStudent:
						clrscr();
                        AddStudent( InsertStudentInfo() );
						getch();
						clrscr();
						break;
					case yBubbleSort:
						clrscr();
                        BubbleSort();
                        printf("=========================================Your Sorted List=========================================\n");
                        ListAllNodes();
						getch();
						clrscr();
						break;
					case yModifiedBubbleSort :
					    clrscr();
						ModifiedBubbleSort();
                        printf("=========================================Your Sorted List=========================================\n");
                        ListAllNodes();
						getch();
						clrscr();
						break;
                    case yMergeSort:
						clrscr();
                        EnterBounds();
                        MergeSort(start,end);
                        printf("=========================================Your Sorted List=========================================\n");
                        ListAllNodes();
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
                    case yPrintStudentByID:
						clrscr();
                        printf("Enter Student ID:   ");
                        scanf("%d",&ID);
						PrintStudentById(ID);
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
				y = yAddStudent;
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
    gotoxy(x,yAddStudent);
	_cprintf("1.Add a Student");
	gotoxy(x,yBubbleSort);
	_cprintf("2.Bubble Sort By ID");
	gotoxy(x,yModifiedBubbleSort);
	_cprintf("3.Modified Bubble Sort By Name");
	gotoxy(x,yMergeSort);
	_cprintf("4.Merge Sort");
	gotoxy(x,yFreeList);
	_cprintf("5.Delete All Students");
    gotoxy(x,yPrintStudentByID);
	_cprintf("6.PrintStudentById");
	gotoxy(x,yListAllStudents);
	_cprintf("7.List All Students");
	gotoxy(x,yExit);
	_cprintf("8.Exit");
}

void findColor(int y) {
	textcolor(RED);
	textbackground(WHITE);
	switch (y)
				{
                    case yAddStudent:
						_cprintf("1.Add a Student");
						break;
					case yBubbleSort:
						_cprintf("2.Bubble Sort By ID");
						break;
                    case yModifiedBubbleSort:
						_cprintf("3.Modified Bubble Sort By Name");
						break;
                    case yMergeSort:
						_cprintf("4.Merge Sort");
						break;
					case yFreeList:
						_cprintf("5.Delete All Students");
						break;
                    case yPrintStudentByID:
						_cprintf("6.PrintStudentById");
						break;
					case yListAllStudents:
						_cprintf("7.List All Students");
						break;
					case yExit:
						_cprintf("8.Exit");
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
void AddStudent (struct Student newStd) {
    ar[Size] = newStd;
    Size++;
}

void PrintStudentById (int reqID) {
	int i,j,isFound;
    isFound = 0;
    for (i = 0 ; i < Size ; i++) {
        if (ar[i].id == reqID) {
            printf("\n***************** Student Num %d ******************\n",ar[i].id);
	        printf("\nStudent ID : %d\n", ar[i].id);
	        printf("\nStudent Name : %s\n", ar[i].name);
            for (j=0 ; j< 3 ; j++) printf("Grade of subject(%d) : %d\n", j+1 ,ar[i].grades[j]);
            isFound = 1;
        }
    }
    if (!isFound) printf("No Student Found with this ID");
}

void FreeList(void) {
	Size = 0;
    printf("All Students Deleted !");
}

void ListAllNodes (void) {
	int i , j;
	for (i = 0 ; i < Size ; i++) {
		printf("***************** Student Num %d ******************\n",i+1);
		printf("Student ID : %d\n",ar[i].id);
		printf("Student Name : %s\n",ar[i].name);
		for (j=0 ; j< 3 ; j++) printf("Grade of subject(%d) : %d\n", j+1 ,ar[i].grades[j]);
	}
}
//============== BubbleSort ==================//
void BubbleSort (void) {
    int j , i;
    struct Student temp;
    for (i = 0 ; i < Size - 1 ; i++) {
        for (j=0 ; j < Size - 1 - i ; j++) {
            if ( ar[j].id > ar[j+1].id ) {
                temp = ar[j];
                ar[j] = ar[j+1];
                ar[j+1] = temp;
            }
        }
    }

}
//============== Modified Bubble Sort ==================//
void ModifiedBubbleSort (void) {
    int j , i;
    struct Student temp;
    int isSwap = 1;
    for (i = 0 ; i < Size - 1 && isSwap ; i++) {
        isSwap = 0;
        for (j=0 ; j < Size - 1 - i ; j++) {
            if ( strcmp( ar[j].name , ar[j+1].name ) > 0 ) {
                temp = ar[j];
                ar[j] = ar[j+1];
                ar[j+1] = temp;
                isSwap = 1;
            }
        }
    }

}
//============== Merge Sort ==================//
void Merge (int low , int middle , int high) {
    struct Student temp [20];
    int list1 , list2 , i;
    list1 = low;
    list2 = middle + 1;
    i = low;
// I. From the Original Array to The Temporary Array
//====================================================================
    //============ NONE OF THE LISTS ENDED ============//
    while (list1 <= middle && list2 <= high) {
        if ( ar[list1].id <= ar[list2].id ) {
            temp[i] = ar[list1];
            list1++;
            i++;
        } else {
            temp[i] = ar[list2];
            list2++;
            i++;
        }
    }
    //============ ONE OF THE LIST ENDED ============//
    if (list1 > middle) { //===== list 1 ended =====//
        while (list2 <= high) {
            temp[i] = ar[list2];
            list2++;
            i++;
        }
    } else { //===== list 2 ended =====//
        while (list1 <= middle) {
            temp[i] = ar[list1];
            list1++;
            i++;
        }
    }
// II. From the Temporary Array to The Original Array
//====================================================================
    for (i = low ; i < high ; i++) {
        ar[i] = temp[i];
    }
}
void MergeSort(int LB , int UB) {
    int middle;
    if (LB < UB) {
        middle = (LB + UB) / 2;
        MergeSort(LB , middle);
        MergeSort(middle+1 , UB);
        Merge(LB , middle , UB);
    }

}
void EnterBounds (void) {
	do {
    	printf("Enter the Lower Bound Index..    ");
    	scanf("%d",&start);
	} while (start < 0);

	do {
    	printf("Enter the Upper Bound Index..    ");
    	scanf("%d",&end);
	} while (end > Size);
}


