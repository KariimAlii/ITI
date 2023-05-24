#include <stdio.h>
#include <stdlib.h>

struct Node
{
    int Data;
    struct Node* pNext; // FORWARD LINKDED LIST
};
struct Node* pHead;
struct Node* pTail;

int InQueue (int d);
int DeQueue (void);
int main()
{
    printf("Hello world!\n");
    return 0;
}
int InQueue (int d)
{
    int retval = 0;
    struct Node* ptr;
    ptr = (struct Node*) malloc(1 * sizeof(struct Node));
    if (ptr) // dynamic allocation success
    {
        ptr -> Data = d;
        ptr -> pNext = NULL;
        if (!pHead) // pHead == NULL // NO LIST
        {
            pHead = pTail = ptr;
        }
        else
        {
            pTail -> pNext = ptr;
            pTail = ptr;
        }
        retval = 1;
    }

    return retval;
}
struct Node* DeQueue (void)
{
    struct Node* ptr = NULL;
    ptr = pHead;
    if (ptr) // THERE IS A LIST
    {
        pHead = pHead -> pNext;
        if (pHead == NULL) // THERE WERE ONLY ONE NODE IN THE LIST
        {
            pTail = NULL;
        }
    }
    return ptr;
}
