class Map{
    int[] location = {1,3,2,5,2,3,1,0};
    Dictionary<string, (int X, int Y)> map = new Dictionary<string, (int X, int Y)>();

    bool mapDone = false;
    int y = 0;

    int startValue = 28; 
    int gapValue = 0;    
    int gapValue2 = 0; 
    public Map(Space pos)
    {        
        map.Add("Local Farm", (0, 0));
        map.Add("Construction Site", (0, 1));
        map.Add("Industrial Area", (1, 1));
        map.Add("Private Company", (2, 1));
        map.Add("Bank", (0, 2));
        map.Add("Local Associations", (1, 2));
        map.Add("Local Billionaire", (0, 3));
        map.Add("Finance Square", (1, 3));
        map.Add("Town Square", (2, 3));
        map.Add("Community Neighborhood", (3, 3));
        map.Add("Homeless Shelter", (4, 3));
        map.Add("Law Firm", (0, 4));
        map.Add("Local Festival", (1, 4));
        map.Add("Hospital", (0, 5));
        map.Add("Public service", (1, 5));
        map.Add("School", (2, 5));
        map.Add("Nursing Home", (0, 6));

        var currentPos = map[pos.GetName()];
        int posX = currentPos.X;
        int posY = currentPos.Y;
        
        while(mapDone == false){
            
            string startIndent = new string(' ', startValue);
    
            // Top of part of the square
            Console.Write(startIndent); 
            for (int x = 0; x < location[y]; x++){
                if (x > 0) {
                    // Make differnet gab value if there is 5 locations
                    if (location[y] == 5) {
                        int currentGap = (x == 1 || x == 4) ? gapValue : gapValue2;
                        Console.Write(new string(' ', currentGap));
                    } else {
                        Console.Write(new string(' ', gapValue));
                    }
                }
                Console.Write(" _____ ");
            }
            Console.WriteLine("");
    
            // Middle part of the square
            Console.Write(startIndent); 
            for (int x = 0; x < location[y]; x++){
                if (x > 0) {
                    if (location[y] == 5) {
                        int nuværendeGap = (x == 1 || x == 4) ? gapValue : gapValue2;
                        Console.Write(new string(' ', nuværendeGap));
                    } else {
                        Console.Write(new string(' ', gapValue));
                    }
                }
                if (x == posX && y == posY){
                    Console.Write("|  X  |");
                }else{
                    Console.Write("|     |");
                }
            }
            Console.WriteLine("");
    
            // Bottom part of the square
            Console.Write(startIndent); 
            for (int x = 0; x < location[y]; x++){
                if (x > 0) {
                    if (location[y] == 5) {
                        int nuværendeGap = (x == 1 || x == 4) ? gapValue : gapValue2;
                        Console.Write(new string(' ', nuværendeGap));
                    } else {
                        Console.Write(new string(' ', gapValue));
                    }
                }
                Console.Write("|_____|");
            }
            
            Console.WriteLine("");
            y++;

            
            switch(location[y]) 
            {
                case 1:
                    startValue = 28; 
                    gapValue = 0;  
                    break;
                case 2:
                    startValue = 10; 
                    gapValue = 29; 
                    break;
                case 3:
                    startValue = 20; 
                    gapValue = 1; 
                    break;
                case 5:
                    startValue = 1;  
                    gapValue = 2;    
                    gapValue2 = 11;
                    break;    
                default:
                    mapDone = true;
                    break;
            }
        }
    }
}