//The array is a data structure used to store homogeneous elements at contiguous locations. The size of an array must be provided before storing data. 

// Let size of array be n.
//     Accessing Time: O(1) [This is possible because elements
// are stored at contiguous locations]   
// Search Time:   O(n) for Sequential Search: 
// O(log n) for Binary Search [If Array is sorted]
// Insertion Time: O(n) [The worst case occurs when insertion 
// happens at the Beginning of an array and 
// requires shifting all of the elements]
// Deletion Time: O(n) [The worst case occurs when deletion 
// happens at the Beginning of an array and 
// requires shifting all of the elements]

//In most of programming languages arrays is provided from the box.

var arrayOfInts = new int[10]{0,1,2,3,4,5,6,7,8,9};
var arrayOnInts2Dim = new int[2,2]{{1,1},{1,1}};
var arrayOfIntsSaw = new int[3][];
arrayOfIntsSaw[0] = new[] { 1, 2, 3 };
arrayOfIntsSaw[1] = new[] { 4, 5};
arrayOfIntsSaw[2] = new[] { 6 };

int SecondMinimal(IReadOnlyList<int> array)
{
    int min1, min2;
    if (array[0]<array[1]) {
        min1 = array[0];
        min2 = array[1];
    }
    else {
        min1 = array[0];
        min2 = array[1];
    }
    for (var i = 2; i < array.Count / 2; i++) {
        if(array[i]<min1){
            min2 = min1;
            min1 = array[i];
        }
        else {
            if(array[i]<min2){
                min2 = array[i];
            }
        }
    }
    return min2;
}
