import React,{Component} from 'react';

class GetHotels extends Component {
  constructor(props){
    super(props);
    this.state={
      HotelList:[],
      isLoaded:false,
    }
  }

  componentDidMount(){
    fetch("https://localhost:44384/api/getHotels") 
      .then(res => res.json())
      .then(json => { 
          this.setState({
            isLoaded: true,
            HotelList: json,
          })
      });
  }


  render(){

      var{isLoaded, HotelList} = this.state;

      if (!isLoaded){
        return <div>Loading...</div>
      }
      else{
       
        return(
          <div>
              <h2>SVI HOTELI</h2>
            <table class="Hotel">
                <tr>
                    <th>Name of Hotel</th>
                    <th>Addres</th>
                    <th>Cost per Night</th>
                </tr>
                <tbody>
                {HotelList.map(getHotels => {
                    return (
                        <tr key={getHotels.HotelId}>
                            <td>{getHotels.HotelName}</td>
                            <td>{getHotels.FullAddress}</td>
                            <td>{getHotels.NightPrice}</td>
                        </tr>
                    )
                    }) }
                </tbody>   
            </table>
          </div>
    );
  }
}
}
export default GetHotels;
