/* World class for modeling the entire in-game world
 */

class World
{
  Space square;

  public World()
  {
    Space square = new Space("Town Square", "You are now in the middle of the city", "dette er et dilemma");
    Space community = new Space("Community Neighborhood");
    Space industrial = new Space("Industrial Area");
    Space finance = new Space("Finance Square");
    Space service = new Space("Public service");
    Space festival = new Space("Local Festival");
    Space shelter = new Space("Homeless Shelter");
    Space sport = new Space("Local Associations", "Welcome to the Local Associations! We're all very excited to host you!");
    Space company = new Space("Private Company", "Welcome to the Private Company! Do you want to get down to buisness?");
    Space farm = new Space("Local Farm", "Welcome to the Local Farm! Would you like some of my produce? Could give you a great discount... for an exchange in services...");
    Space construction = new Space("Construction Site", "Welcome to the Construction Site! Could you give us a hand?");
    Space bank = new Space("Bank");
    Space billionaire = new Space("Local Billionaire");
    Space lawyer = new Space("Law Firm");
    Space hospital = new Space("Hospital");
    Space nursing = new Space("Nursing Home");
    Space school = new Space("School");

//edge from square
    square.AddEdge("north", industrial);
    square.AddEdge("east", community);
    square.AddEdge("south", service);
    square.AddEdge("west", finance);

    // ------------------------------------------------
//egde from industrial to room
    industrial.AddEdge("company", company);
    industrial.AddEdge("farm", farm);
    industrial.AddEdge("construction", construction);
    industrial.AddEdge("back", square);
//edge from room to industrial
    company.AddEdge("back", industrial);
    farm.AddEdge("back", industrial);
    construction.AddEdge("back", industrial);

    //________________________________________________________  
//edge from community to room
    community.AddEdge("sport", sport);
    community.AddEdge("shelter", shelter);
    community.AddEdge("festival", festival);
    community.AddEdge("back", square);
//edge from room to community
    sport.AddEdge("back", community);
    shelter.AddEdge("back", community);
    festival.AddEdge("back", community);

    // _______________________________________________
//edge from service to room
    service.AddEdge("school", school);
    service.AddEdge("nursing", nursing);
    service.AddEdge("hospital", hospital);
    service.AddEdge("back", square);
//edge from room to service
    school.AddEdge("back", service);
    nursing.AddEdge("back", service);
    hospital.AddEdge("back", service);

    // _______________________________________________
//edge from finance to room
    finance.AddEdge("bank", bank);
    finance.AddEdge("billionaire", billionaire);
    finance.AddEdge("lawyer", lawyer);
    finance.AddEdge("back", square);
//edge from room to finance
    bank.AddEdge("back", finance);
    billionaire.AddEdge("back", finance);
    lawyer.AddEdge("back", finance);



    this.square = square;
  }

  public Space GetEntry()
  {
    return square;
  }
}

