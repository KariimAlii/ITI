int main()
{

#include<stdio.h>
#include<conio.h>

char pwd[8];
int i;

printf("Enter Your Password of 8 characters ..\n");
for (i=0 ; i < 8 ; i++)
{
pwd[i] = getch();
printf("*");
}
// pwd[i]='\0';  used with defining char pwd[9]
printf("\n");
printf("Your Password is: \"");

for(i=0; i<8 ; i++)
{
printf("%c",pwd[i]);
}
printf("\"");


getch();
clrscr();

return 0;
}