#include <stdio.h>
#include <conio.h>
#include <string.h>
int main()
{
char FullName[12];
char FirstName[6];
char LastName[4];

char Middle[] = {" "};

printf("Enter Your First Name\n");
scanf("%s",FirstName);

printf("Enter Your Last Name\n");
scanf("%s",LastName);

strcpy(FullName,FirstName);
strcat(FullName,Middle);
strcat(FullName,LastName);

printf("Your Full Name is %s",FullName);





getch();
clrscr();
return 0;
}