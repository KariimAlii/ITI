#include <stdio.h>
#include <stdlib.h>

int main()
{


//================ Q3 - 2 =============//
int x , y ;
printf("Enter First Num");
scanf("%d",&x);
printf("Enter Second Num");
scanf("%d",&y);
printf("Devision %d / %d = %d",x,y,x/y);
return 0;
}

//    //================1=============//
//    char* ch;
//    *ch = 'c';
//    printf("%c" , *ch);
//    return 0;

//int main()
//{
////================3=============//
//    int * ptr;
//    int ar[2] = {1,2};
//    ptr = ar;
//    ptr++;
//    ar++;
//    printf("The First Num is : %d\n",ptr[0]);
//    printf("The Second Num is : %d\n",ptr[1]);
//
//    return 0;
//}

    //==============2=============//
//    int I = 1;
//
//    for (I<5 ; I = 0 ; I++) {
//        printf("%d",I);
//    }

     //==============16 INTAKE 42=============//
//     int k = 0;
//     for ( printf("FLOWER "); printf("YELLOW ") ;printf("Fruits ") )
//     {
//        printf("%d\n",k);
//        k++;
//        if (k==5) break;
//     }
//    return 0;

    //==============11=============//
//    int myArray[] = {1,2,3};
//    printf("First Element : %d \n",myArray[0]);
//    printf("Size of one int : %d Byte \n", sizeof(int) );
//    printf("Size of Array : %d Bytes", sizeof(myArray) );
//    return 0;



////================5=============//
//
//struct Student
//{
//    int x;
//    char y;
//    int z;
//    char ar[2];
//};
//int main()
//{

//    struct Student karim ;
//    karim.x = 2;
//    karim.y = 'k';
//    karim.z = 3;
//    karim.ar[0] = 1;
//    karim.ar[1] = 2;
//    printf("x :%d \n",karim.x);
//    printf("y :%c \n",karim.y);
//    printf("z :%d \n",karim.z);
//    printf("first element in array :%d \n",karim.ar[0]);
//    printf("second element in array :%d \n",karim.ar[1]);
//    printf("*******************************************************************************\n");
//    printf("Address of x :%p in hexadecimal \n",&karim.x);
//    printf("Address of y :%p in hexadecimal \n",&karim.y);
//    printf("Address of z :%p in hexadecimal \n",&karim.z);
//    printf("Address of first element in array :%p in hexadecimal \n",&karim.ar[0]);
//    printf("Address of second element in array :%p in hexadecimal \n",&karim.ar[1]);
//        printf("*******************************************************************************\n");
//    printf("Address of x :%d in decimal \n",&karim.x);
//    printf("Address of y :%d in decimal \n",&karim.y);
//    printf("Address of z :%d in decimal \n",&karim.z);
//    printf("Address of first element in array :%d in decimal \n",&karim.ar[0]);
//    printf("Address of second element in array :%d in decimal \n",&karim.ar[1]);
//    return 0;
//}


////================ 12 =============//
//int i;
//for (i=0 ; i <= 10 ; i+=5) {
//    printf("i= %d \t",i+1);
//}

//================ Q3 - 1 =============//
int n , i , j;
printf("Enter No of users");
scanf("%d",&n);
for (i = 0;i <= n ; i++) {
    for (j = 0;j <= i ; j++)
    {
        printf("*");

    }
    printf("\n");
}
