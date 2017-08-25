import React from "react";

import Footer from "./Footer";
import Header from "./Header";



export default class Layout extends React.Component {
    constructor() {
        super();
        this.state = {
          title: "Hello",
          name: "Mike"
        };
      }

    render() {
        const title = "Welcome Bob!";
        var title2 = "Welcome George!";
        let title3 = "Welcome Henry!";


        title2 = "hiya";
        title3 = "hey";
        //title = "hey there";
        
        // let title4 : string = "Welcome Henry!";
        
/*         setTimeout(() => {
            this.setState({title: "Hello"});
        }, 2000); */


        return (
          <div>
            <Header title={this.state.title} name={this.state.name} />
            <Header title={this.state.title}  />
            <Header title={title} name={""} />
            <Header title={title} />
            <Header title={"Other Title"} />
            <Header title={title2} />
            <Header title={title3} />
            <Footer />
          </div>
        );
      }


}

