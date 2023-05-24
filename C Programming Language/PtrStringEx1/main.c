#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int main()
{
    char multiple [] = {"a string"};
    char * p = multiple;
    int i;
    for (i = 0; i < strlen(multiple);i++)
    {
        printf("multiple[%d] = %c *(p+%d) = %c &multiple[%d] = %p p+%d = %p \n",
                         i , *(p+i) , i ,  *(p+i),       i,&multiple[i],i,p+i);
    }
    return 0;
}

