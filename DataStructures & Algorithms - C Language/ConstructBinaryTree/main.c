#include <stdio.h>
#include <stdlib.h>
struct Node
{
    int Data;
    struct Node *pLeft;
    struct Node *pRight;
};

struct Node *CreateNode(int d)
{
    struct Node *pNode = NULL;
    pNode = (struct Node *)malloc(sizeof(struct Node));
    if (pNode)
    {
        pNode->Data = d;
        pNode->pLeft = pNode->pRight = NULL;
    }
    return pNode;
};
struct Node *InsertNode(struct Node *pRoot, int d)
{
    if (pRoot == NULL)
        pRoot = CreateNode(d);
    else if (d >= pRoot->Data)
        pRoot->pRight = InsertNode(pRoot->pRight, d);
    else
        pRoot->pLeft = InsertNode(pRoot->pLeft, d);
    return pRoot;
};
void InOrder(struct Node *pRoot)
{ // Left - Root - Right
    if (pRoot)
    {
        InOrder(pRoot->pLeft);
        printf("%d -> ", pRoot->Data);
        InOrder(pRoot->pRight);
    }
};
void DeleteAll(struct Node *pRoot)
{
    if (pRoot)
    {
        DeleteAll(pRoot->pLeft);
        DeleteAll(pRoot->pRight);
        free(pRoot);
    }
};
int S = 0;
int Sum(struct Node *pRoot)
{
    if (pRoot == NULL)
        return 0;
    // First Method
    //===============
    // int sum = pRoot->Data + Sum(pRoot->pLeft) + Sum(pRoot->pRight);
    // return sum;
    // Second Method
    //===============
    Sum(pRoot->pLeft);
    S += pRoot->Data;
    Sum(pRoot->pRight);
    return S;
}
struct Node *DeleteNode(struct Node *pRoot, int d)
{
    // I. Base Case
    //=================
    if (pRoot == NULL)
        return pRoot;
    // II. Recursive Case
    //======================
    if (d > pRoot->Data)
        pRoot->pRight = DeleteNode(pRoot->pRight, d);
    else if (d < pRoot->Data)
        pRoot->pLeft = DeleteNode(pRoot->pLeft, d);
    else // (pRoot->Data == d)
    {
        if (pRoot->pLeft == NULL && pRoot->pRight == NULL)
        { // 0 Child
            struct Node *temp = pRoot -> pLeft;
            free(pRoot);
            return temp;
        }
        else if (pRoot->pLeft && pRoot->pRight)
        { // 2 Child
            struct Node *ptr;
            ptr = pRoot->pRight;
            while (ptr->pLeft)
            {
                ptr = ptr->pLeft;
            }
            pRoot -> Data = ptr -> Data;
            pRoot ->pRight = DeleteNode(pRoot ->pRight,ptr->Data);
        }
        else if (pRoot->pLeft || pRoot->pRight)
        { // 1 Child
            if (pRoot->pLeft)
            { // Left Child
                struct Node* temp;
                temp = pRoot->pLeft;
                free(pRoot);
                return temp;
            }
            else
            { // Right Child
                struct Node* temp;
                temp = pRoot->pRight;
                free(pRoot);
                return temp;
            }
        }
        
    }
    return pRoot;
}
int main()
{
    struct Node *pRoot = NULL;
    pRoot = InsertNode(pRoot, 5);
    pRoot = InsertNode(pRoot, 2);
    pRoot = InsertNode(pRoot, 22);
    pRoot = InsertNode(pRoot, 1);
    pRoot = InsertNode(pRoot, 3);
    pRoot = InsertNode(pRoot, 18);
    pRoot = InsertNode(pRoot, 31);
    pRoot = InsertNode(pRoot, 29);
    pRoot = InsertNode(pRoot, 35);
    pRoot = InsertNode(pRoot, 27);

    InOrder(pRoot);
    pRoot = DeleteNode(pRoot, 22);
    printf("\n");
    InOrder(pRoot);
    return 0;
}
