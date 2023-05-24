 #include<stdio.h>
 #include<conio.h>

 int main()
 {
 int N,Num,Col,Row;


 //=====================Magic Box================//
 // I. Inserting Size
 do
 {

 printf("Enter The Size of Your Magic Box! Odd Number Please:)   ");
 scanf("%d",&N);
 printf("\n");

 } while (N % 2 == 0);

 // II.Position of Num1
 Num = 1;
 Col = ( Num + N ) / 2;
 Row = 1;
 gotoxy(Col+5,Row+5);
 printf("%d",Num);

 //III. Loop to fill Numbers (2 -> N)
 for (Num = 2 ; Num <= N*N ; Num++)
 {


 if( (Num - 1) % N == 0 ) Row++ ;
 else
 {
 Row--;
 Col--;
 }


 if (Row < 1) Row = N;
 if (Col < 1) Col = N;

 gotoxy(Col+5,Row+5);
 printf("%d",Num);

 }

 getch();
 clrscr();
 return 0;
 }