#include <stdio.h>
#include <conio.h>
#include <stdlib.h>

struct Student
{
	int id;
	char name[20];
	int grade[3];


};
void FillStd (struct Student * ptr , int Num)
{
int i,j;

for (i=0;i<Num;i++)
	{
		printf("Enter Student Number %d ID..     ",i+1);
		scanf("%d",&(ptr+i)->id);
		printf("Enter Student Number %d Name..     ",i+1);
		scanf("%s",(ptr+i)->name);
		for (j=0;j<3;j++)
			{
			  printf("Enter Student Number %d Grade in Subject (%d)..       ", i+1 ,j+1);
			  scanf("%d",&(ptr+i)->grade[j]);
			}

	}

};
void PrintStd (struct Student * ptr, int Num)
{
int i,j;

printf("**************************************\n");

for (i=0;i<Num;i++)
	{
		printf("Student Number %d ID: %d\n", i+1 , (ptr+i)->id );

		printf("Student Number %d Name: %s\n",i+1 , (ptr+i)->name );

		for (j=0;j<3;j++)
			{
			  printf("Student Number %d Grade in Subject (%d): %d\n", i+1 ,j+1, (ptr+i)->grade[j] );

			}

	}

printf("************************************\n");

};

int main ()
{

//========================== Declaration ===========================//

int Num;
struct Student* ptr;

clrscr();

printf("Enter Required Number of Students");
scanf("%d",& Num);
ptr = (struct Student*) malloc( Num * sizeof(struct Student) ) ;

FillStd(ptr,Num);
PrintStd(ptr,Num);
getch();
return 0;
}