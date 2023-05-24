#include<stdio.h>
#include<conio.h>

int main ()
{
char ch;
ch = getch();
if (ch == 0) // Extended Key
{

ch=getch();
printf("Extended Key with Ascii: %d",ch) ;

}
else  printf("Normal Key with Ascii: %d",ch)




}