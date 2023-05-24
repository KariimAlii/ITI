#include <stdio.h>
#include <stdlib.h>
int calcSum (int ar[],int n);
int main()
{
    int ar[10] = {1,1,1,1,1,1,1,1,1,1};
    printf("Sum is %d \n",calcSum(ar,10));
    return 0;
}
int calcSum (int *ptr,int n)
{
    int Sum = 0;
    int* const arrayEnd = ptr+n;

    for (;ptr < arrayEnd;ptr++)
    {
        Sum += *ptr;
    }
    return Sum;
}
