#include <stdio.h>
#include <conio.h>
int main()
{

char FirstName[6];
char LastName[4];
int x , y ;


for (x = 0; x < 6 ; x++)
{
printf("Enter Character(%d) of the First Name\n",x);
scanf("%c",&FirstName[x]);

}
printf("First Name: ");
x = 0;
while(FirstName[x] != 0)
{
printf("%c",FirstName[x]);
x++;
}






getch();
clrscr();
return 0;
}