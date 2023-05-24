#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <windows.h>

#define ArrowRight 77
#define ArrowLeft 75
#define Escape 27
#define Enter 13
#define Home 71
#define End 79

void gotoxy(short col, short row)
{

COORD position={col,row};
SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),position);
}

void clrscr (void)
{
     system("cls");
}
int main()
{

//================== Declaration ================//
int App=1 , x=1 , y=1 , S , i , L=0 ;
char Ascii;
char* ptr;

clrscr();

//================ Dynamic Memory Allocation ===============//
printf("Enter The Size of String.......    ");
scanf("%d",&S);
clrscr();
ptr = (char*) malloc(S * sizeof(char) );
if (ptr != NULL)
{


//===================Keys========================//

	while (App != 0)
	{
	Ascii = getch();
	if (Ascii == 0) Ascii = getch();
		switch(Ascii)
		{
			case ArrowRight:
				x++;
				gotoxy(x,y);
				break;

			case ArrowLeft:
				x--;
				gotoxy(x,y);
				break;
			case Home:
				x=1;
				gotoxy(x,y);
				break;
			case End:
				x=L+1;
				gotoxy(x,y);
				break;
			case Escape:
				App=0;
				break;

			case Enter:
				clrscr();
				gotoxy(15,15);
				for(i=0;i<L;i++) printf("%c",*(ptr+i));
				break;
			default:
				*(ptr+L) =(char) Ascii;
				L++;
				x=L+1;
				*(ptr+L) = '\0';
				clrscr();
                gotoxy(1,1);
				for(i=0;i<L;i++)
				{
				     printf("%c",*(ptr+i));
				}
                gotoxy(x,1);
		}


	}





free(ptr);
}
else printf("No Memory to Allocate :(");
if(Ascii != Escape) getch();
return 0;

}
