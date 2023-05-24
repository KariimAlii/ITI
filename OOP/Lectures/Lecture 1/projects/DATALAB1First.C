#include <stdio.h>
#include <conio.h>
#include <stdlib.h>

#define yAdd 1
#define ySubtract 2
#define yMultiply 3
#define yDevide 4
#define yExit 5
#define ArrowUp 72
#define ArrowDown 80
#define Enter 13
#define Escape 27
#define Home 71
#define End 79
//================ Functions Prototype =================//
void PrintMenu(int x);
int getFirstNum(void);
int getSecondNum(void);
int Add(int a , int b);
int Subtract(int a , int b);
int Multiply(int a , int b);
int Devide(int a , int b);
void Exit(void);
void findColor(int y);
//============== Double Linked List ==================//
struct Student 
{
    int id ;
    char name[20];
    int grades[3];
};
struct Node
{
    struct Student std;
    struct Node* pPrev;
    struct Node* pNext;
};
struct Node* pHead; // =NULL
struct Node* pTail; // =NULL
int AddNode (struct Student newStd);
int InsertNode (struct Student newStd , int loc);
struct Node* CreateNode(struct Student newStd);
struct Node* SearchNode(struct Student std);
int DeleteNode (int loc);
void FreeList(void);
//======================================================================

int main ()
{
// I. Variables Declaration

	int x = 1 , y  , a , b , result , App = 1 ;

	char Ascii , ch;


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
				if (y == yAdd)
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
					y = yAdd;
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
					case yAdd:
                        gotoxy(10,10);
						a = getFirstNum();
						gotoxy(10,11);
						b = getSecondNum();
						result = Add(a,b);
						gotoxy(10,12);
						printf("Your Result a + b = %d",result);
						App = 0;
						break;
					case ySubtract:
						gotoxy(10,10);
						a = getFirstNum();
						gotoxy(10,11);
						b = getSecondNum();
						result = Subtract(a,b);
						gotoxy(10,12);
						printf("Your Result a - b = %d",result);
						App = 0;
						break;
					case yMultiply:
						gotoxy(10,10);
						a = getFirstNum();
						gotoxy(10,11);
						b = getSecondNum();
						result = Multiply(a,b);
						gotoxy(10,12);
						printf("Your Result a * b = %d",result);
						App = 0;
						break;
					case yDevide:
						gotoxy(10,10);
						a = getFirstNum();
						gotoxy(10,11);
						b = getSecondNum();
						result = Devide(a,b);
						gotoxy(10,12);
						printf("Your Result a / b = %d",result);
						App = 0;
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
				y = yAdd;
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
	gotoxy(x,yAdd);
	cprintf("1.Add");
	gotoxy(x,ySubtract);
	cprintf("2.Subtract");
	gotoxy(x,yMultiply);
	cprintf("3.Multiply");
	gotoxy(x,yDevide);
	cprintf("4.Devide");
	gotoxy(x,yExit);
	cprintf("5.Exit");
}
int getFirstNum(void) {
	int a;
	printf("Enter the first Number a:");
	scanf("%d",&a);
	return a;
};
int getSecondNum(void) {
	int b;
	printf("Enter the Second Number b:");
	scanf("%d",&b);
	return b;
};
int Add(int a , int b){
	return a+b ;
};
int Subtract(int a , int b) {
	return a-b ;
};
int Multiply(int a , int b) {
	return a*b ;
};
int Devide(int a , int b) {
	return a/b ;
};
void findColor(int y) {
	textcolor(RED);
	textbackground(WHITE);
	switch (y) 
				{
					case yAdd:
						cprintf("1.Add");
						break;
					case ySubtract:
						cprintf("2.Subtract");
						break;
					case yMultiply:
						cprintf("3.Multiply");
						break;
					case yDevide:
						cprintf("4.Devide");
						break;
					case yExit:
						cprintf("5.Exit");
						break;
				}
}

struct Node* CreateNode(struct Student newStd) {
    struct Node* ptr;
    ptr = (struct Node *) malloc( sizeof(struct Node) );
    if (ptr) {    // !=NULL
        ptr -> std = newStd ;
        ptr -> pNext = ptr -> pPrev = NULL ;
    }
    return ptr; 
}
int AddNode (struct Student newStd) {
    int retval = 0;
    struct Node* pCur ;
    pCur = CreateNode(newStd) ;
    if (pCur) { // = address ( Dynamic ALlocation Success ) (Node Created successfully)
        retval = 1;
        if (pHead == NULL) {    // No List
            pHead = pCur;
            pTail = pCur;
        }
        else { 
            pTail -> pNext = pCur;
            pCur -> pPrev = pTail;
            pTail = pCur; 
        }   
    }
    return retval;
}
struct Node* SearchNode(struct Student reqStd) {
    struct Node* ptr;
    ptr = pHead;
//========================================First Method========================================//
    // Pausing Search When Reaching the last Node
    // ** In this Way we don't check on the data stored in the last Node
    // while (ptr -> pNext != NULL) { // Not pointing to the last node in linked list
    //     if (ptr -> std == reqStd) {
    //         return ptr;
    //     }
    //     else {
    //         ptr = ptr -> pNext;
    //     }
    // }
    // return ptr -> pNext; // NULL (pointing to last Node)
//========================================Second Method========================================//
    // Resuming Search When Reaching the last Node
    // if the last Node doesn't contain the required data ==> we move to the next address (NULL)
    // If the pointer points to NULL ==> We went out boundaries of our Linked List ==> We havenot found the required Data ==> Just Return NULL
    while (ptr -> std != reqStd && ptr != NULL) {
        ptr = ptr -> pNext;
    }
    return ptr;
}
void FreeList(void) {
	struct Node* ptr;
	while (pHead) {   // (pHead != NULL)
		ptr = pHead;
		pHead = pHead -> pNext;
		free(ptr);
	}
	pTail = NULL;
}
int InsertNode (struct Student newStd , int loc) {
	struct Node *temp,*ptr;
	int retval = 0 , i;
	ptr = CreateNode(newStd);
	if (ptr) {        // New Node created successfully
		retval = 1;
		if (pHead == NULL) { // No List
			pHead = pTail = ptr;
		} else { 
			if (loc == 0) { // First Node
				ptr -> pNext = pHead;
				pHead -> pPrev = ptr;
				pHead = ptr;
			} else { // Middle or Last
				temp = pHead;
				for (i = 0 ; i < loc - 1 && temp ; i++) temp = temp -> pNext;
				if (temp == pTail || temp == NULL) { // last
					pTail -> pNext = ptr;
					ptr -> pPrev = pTail;
					pTail = ptr;
				} else { // middle
					(temp -> pNext) -> pPrev = ptr;
					ptr -> pNext = temp -> pNext;
					ptr -> pPrev = temp;
					temp -> pNext = ptr;
				}
			}
		}
	}
}
int DeleteNode (int loc) {
	struct Node *temp,*ptr;
	int retval = 0 , i;
	ptr = CreateNode(newStd);
	if (ptr) {        // New Node created successfully
		retval = 1;
		if (pHead == NULL) { // No List
			pHead = pTail = ptr;
		} else { 
			if (loc == 0) { // First Node
				ptr -> pNext = pHead;
				pHead -> pPrev = ptr;
				pHead = ptr;
			} else { // Middle or Last
				temp = pHead;
				for (i = 0 ; i < loc - 1 && temp ; i++) temp = temp -> pNext;
				if (temp == pTail || temp == NULL) { // last
					pTail -> pNext = ptr;
					ptr -> pPrev = pTail;
					pTail = ptr;
				} else { // middle
					(temp -> pNext) -> pPrev = ptr;
					ptr -> pNext = temp -> pNext;
					ptr -> pPrev = temp;
					temp -> pNext = ptr;
				}
			}
		}
	}
}