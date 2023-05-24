#include <stdio.h>
#include <stdlib.h>
struct Node
{
    int Data;
    struct Node *pNext;
};
int Length = 0;
struct Node* pHead;
int main()
{
    printf("Hello world!\n");
    return 0;
}
int FindLengthIterative(struct Node *pHead)
{
    struct Node* ptr;
    if (pHead) {
        ptr = pHead;
        while (ptr != NULL) {
            Length++;
            ptr = ptr -> pNext;
        }
    }
    return Length;
}
int FindLengthRecursion(struct Node *pHead)
{
    struct Node* ptr = pHead;
    if (pHead)
    {
        while (ptr -> pNext != NULL)
        {
            ptr = ptr->pNext;
            Length++;
            FindLengthRecursion(ptr);
        }
    }
    return Length;
}

