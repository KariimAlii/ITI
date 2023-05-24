#include <stdio.h>
#include <stdlib.h>

int main()
{
    int *ptr , *ptr1;
    int i , Sum = 0;

    ptr = (int*) malloc(6 * sizeof(int));
    if (ptr)
    {
        ptr1 = ptr;
        for (i=0;i<6;i++)
        {
            scanf("%d",ptr1);
            Sum += *ptr1;
            ptr1++ ;
        }
        ptr1=ptr;
        printf("You entered ");
        for (i=0;i<6;i++)
        {
            printf("%d",*ptr1);
            printf(",");
            ptr1++ ;
        }
        printf("\nSum = %d",Sum);
        free(ptr);
    }
    return 0;
}
