#include <stdio.h>
#include <stdlib.h>

// Copying array Elements to another array

void copyString (char from[],char to[])
{
    int i ;
    for (i=0; from[i] != '\0';i++) to[i] = from[i];
    to[i]='\0';
}

// Copying Strings using pointers
void copyString2 (char* from,char* to)
{
    for( ; *from != '\0' ; from++ ; to++)
    {
       *to = *from;
    }
    // while (*from != '\0') *to++ = *from++;
    *to = '\0';
}
int main()
{
    char string1[] = {"karim"};
    char string2[50];
    copyString2(string1,string2);
    printf("%s",string2);
    return 0;
}
