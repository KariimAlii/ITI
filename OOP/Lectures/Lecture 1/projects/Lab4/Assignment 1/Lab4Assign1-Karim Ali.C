#include <stdio.h>
#include <conio.h>
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
		  //========= Functions Prototype ============//
void PrintMenu(int x);
int getFirstNum(void);
int getSecondNum(void);
int Add(int a , int b);
int Subtract(int a , int b);
int Multiply(int a , int b);
int Devide(int a , int b);
void Exit(void);
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
					gotoxy(x,y);
				}
				else 
				{
					y--;
					gotoxy(x,y);
				}
				break;
			case ArrowDown:
				if (y == yExit) 
				{
					y = yAdd;
					gotoxy(x,y);
				}
				else 
				{
					y++;
					gotoxy(x,y);
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
				gotoxy(x,y);
				break;
			case End:
				y = yExit;
				gotoxy(x,y);
				break;
			}
	}
getch();
return 0;
}

// III.Functions

void PrintMenu(x) 
{
	gotoxy(x,yAdd);
	printf("1.Add");
	gotoxy(x,ySubtract);
	printf("2.Subtract");
	gotoxy(x,yMultiply);
	printf("3.Multiply");
	gotoxy(x,yDevide);
	printf("4.Devide");
	gotoxy(x,yExit);
	printf("5.Exit");
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