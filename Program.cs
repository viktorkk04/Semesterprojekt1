int y= 0;
int x= 0;

int mapSize = 6;
string space = "";

//Making a array with two possiable values (x and y)
int[] location = new int[2];

Console.WriteLine("Hvilket retning vil du?");

//Checking for what is written in Console and moving persons location
switch(Console.ReadLine()){
    case "nord":
        location[1] --;
        Console.WriteLine(location[1]);
        break;
    case "syd":
        location[1] ++;
        Console.WriteLine(location[1]);
        break;
    case "øst":
        location[0] ++;
        Console.WriteLine(location[0]);
        break;
    case "vest":
        location[0] --;
        Console.WriteLine(location[0]);
        break;
    default:
        Console.WriteLine("Du har valgmuligheder: nord, syd, øst eller vest");
        break;
    
}

//class map {
for (y = 1; y <= mapSize; y++){
    // Reserverer 140 tegn
    Console.Write($"{space, 145}");
    //Console.Write(y*1);
    for (x = 1; x <= mapSize; x++){
        Console.Write("|");
        Console.Write("-");
    }   
    Console.WriteLine("|");
}
//}