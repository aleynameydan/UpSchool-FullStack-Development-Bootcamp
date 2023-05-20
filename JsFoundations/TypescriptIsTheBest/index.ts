
const car ={
    model: "",
    age: 0,
    location: {
        country: "",
        city: ""
    },
    fines: []
}

car.model = "BMW -9.35";
car.age = 13;
car.location.country = "Turkey";
car.location.city = "İstanbul";

car.fines.push({name: "Trafik cezası", fine: 1500});
