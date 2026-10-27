/* World class for modeling the entire in-game world
 */

class World {
  Space square;
  
  public World () {
    Space square    = new Space("Town Square");
    Space community = new Space("Community");
    Space industrial     = new Space("Industrial");
    Space finance      = new Space("Finance");
    Space service  = new Space("Public service");
    Space festival = new Space("Local Festival");
    Space shelter = new Space("Homeless Shelter");
    Space sport = new Space("Local Associations");
    Space company = new Space("Private Company");
    Space farm = new Space("Local Farm");
    Space construction = new Space("Construction");
    Space bank = new Space("Bank");
    Space billionaire = new Space("Local Billionaire");
    Space lawyer = new Space("Law Firm");
    Space hospital = new Space("Hospital");
    Space nursing = new Space("Nursing Home");
    Space school = new Space("School");
    
    
    square.AddEdge("north", industrial);
    square.AddEdge("east", community);
    square.AddEdge("south", service);
    square.AddEdge("west", finance);

    // ------------------------------------------------
    
    industrial.AddEdge("company", company); 
    industrial.AddEdge("farm", farm);
    industrial.AddEdge("construction", construction);
    industrial.AddEdge("back", square);

    company.AddEdge("back", industrial);
    farm.AddEdge("back", industrial);
    construction.AddEdge("back", industrial);

  //________________________________________________________  

    community.AddEdge("sport", sport);
    community.AddEdge("shelter", shelter);
    community.AddEdge("festival", festival);
    community.AddEdge("back", square);
    
    sport.AddEdge("back", community);
    shelter.AddEdge("back", community);
    festival.AddEdge("back", community);

// _______________________________________________
    
    service.AddEdge("school", school);
    service.AddEdge("nursing", nursing);
    service.AddEdge("hospital", hospital);
    service.AddEdge("back", square);
    
    school.AddEdge("back", service);
    nursing.AddEdge("back", service);
    hospital.AddEdge("back", service);

    // _______________________________________________
        
        finance.AddEdge("bank", bank);
        finance.AddEdge("billionaire", billionaire);
        finance.AddEdge("lawyer", lawyer);
        finance.AddEdge("back", square);
        
        bank.AddEdge("back", finance);
        billionaire.AddEdge("back", finance);
        lawyer.AddEdge("back", finance);
    
    
    
    this.square = square;
  }
  
  public Space GetEntry () {
    return square;
  }
}

