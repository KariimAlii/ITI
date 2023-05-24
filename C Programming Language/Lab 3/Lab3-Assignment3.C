#include<stdio.h>
#include<conio.h>
//======================== MENU APP ==========================//
int main ()
{

//====== Declarations ======//

char Ch,Ascii;
int X,Y,App=5;
//=========== Initialization ==========//
X=1;
Y=1;
// Print The Menu

 gotoxy(1,Y);
 printf("Edit");
 gotoxy(1,Y+1);
 printf("Search");
 gotoxy(1,Y+2);
 printf("Save");
 gotoxy(1,Y+3);
 printf("Exit");
 Y=1;

 gotoxy(X,Y);
while (App != 0 )
{

//I. Check if Normal Or Extended Key and Get the Ascii Code for the key

Ch = getch();

if (Ch == 0) Ascii = getch(); // Extended Key
else Ascii = Ch; // Normal Key

//====== UP ARROW========//
if (Ascii == 72  ) {if(Y==1){Y=4;gotoxy(X,Y);} else { Y--; gotoxy(X,Y);} }
//============DOWN ARROW==========//
if (Ascii == 80  ) { if(Y==4){Y=1;gotoxy(X,Y);} else { Y++; gotoxy(X,Y);} }
//=========ENTER==========//

if (Ascii == 13  )
{
X+=15;
gotoxy(X,Y);
if(Y == 1) printf("You pressed Edit");
if(Y == 2) printf("You pressed Search");
if(Y == 3) printf("You pressed Save");
X-=15;
gotoxy(X,Y);
if(Y == 4) App = 0;
}
//===========ESCAPE============//
if (Ascii == 27  ) { App = 0; }

}

clrscr();
return 0;
}