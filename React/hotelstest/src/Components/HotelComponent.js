import React from 'react';

class HotelComponent extends React.Component{
    constructor (props){
        super(props);
        this.state={
            message:"Enter Values",
            HotelName:null,
            FullAddress:null,
            NightPrice:null,
            Phone : null,
            Email :null,
            NumberOfRooms: null,
            CanCheckIn:null,
            MustCheckOut:null
        };
    }
    
    ChangeValue = (e) => {
        this.setState({[e.target.name]: e.target.value});
    }

    AddHotel = (e) => {

        let hotelInfo = {
            HotelName:this.ref.HotelName.value,
            FullAddress:this.ref.FullAddress.value,
            Phone:this.ref.Phone.value,
            Email:this.ref.Email.value,
            NumberOfRooms:this.ref.NumberOfRooms.value,
            CanCheckIn:this.ref.CanCheckIn.value,
            MustCheckOut:this.ref.MustCheckOut.value,
            NightPrice:this.ref.NightPrice.value
        };


        fetch('https://localhost:44384/api/newHotel',{
            method:'POST',
            headers:{'Content-type' : 'application/json'},
            body:JSON.stringify(hotelInfo)
        }).then(r=>r.json()).then(res=>{
            if(res){
                console.log(JSON.stringify(hotelInfo));
                this.setState({message:'New Hotel is added'});
            }
        })

    }

    render(){
        return(
            <div>
            <form onSubmit={this.AddHotel}>
                <p>
                    <label>
                        Naziv hotela:  
                        <input type="text" placeholder='Hotel name' name='HotelName' onChange={this.ChangeValue}/>
                    </label>
                </p>
                <p>
                    <label>
                        Adresa hotela: 
                        <input type="text" placeholder='Full address' name='FullAddress'onChange={this.ChangeValue} />
                    </label>
                </p>
                <p>
                    <label>
                        Kontakt: 
                        <input type="text" placeholder='+385...' name='Phone' onChange={this.ChangeValue}   />
                    </label>
                </p>
                <p>
                    <label>
                        Email: 
                        <input type="text" placeholder='xxx@xxx' name='Email' onChange={this.ChangeValue}/>
                    </label>
                </p>
                <p>
                    <label>
                        Broj soba: 
                        <input type="text" placeholder='Točan broj soba' name='NumberOfRooms' onChange={this.ChangeValue}NumberOfRooms />
                    </label>
                </p>
                <p>
                    <label>
                        Kada je moguća prijava: 
                        <input type="text" placeholder='hh:mm' name='CanCheckIn' onChange={this.ChangeValue}/>
                    </label>
                </p>
                <p>
                    <label>
                        Obvezna odjava: 
                        <input type="text" placeholder='hh:mm' name='MustCheckOut' onChange={this.ChangeValue}/>
                    </label>
                </p>

                <p>
                    <label>
                        Cijena za noćenje: 
                        <input type="text" placeholder='Cijena noćenja u kunama' name='NightPrice' onChange={this.ChangeValue}NightPrice />
                    </label>
                </p>
                <p>
                    <input type="submit" value="Dodaj hotel" />
                </p>
        <p>{this.state.message}</p>
            </form>
        <p>
        </p>
        </div>
        )
    } 
}
export default HotelComponent;


