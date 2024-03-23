import React from 'react';
// import ReactDOM from 'react-dom';
import Routers from './routes';
import * as ReactDOM from 'react-dom/client';


const root = ReactDOM.createRoot(document.getElementById("root") as HTMLElement);
root.render(
  <React.StrictMode>
    <Routers />
  </React.StrictMode>
);


// ReactDOM.render(
//   <React.StrictMode>
//     <Routers/>
//   </React.StrictMode>,
//     document.getElementById('root')
// );

// import { createRoot } from 'react-dom/client';
// const container = document.getElementById('root');
// const root = createRoot(container); // createRoot(container!) if you use TypeScript
// root.render(<App tab="home" />);