import { type JSX } from "react";
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import './index.css'
import PageHome from "../pages/home";
import PageGuests from "../pages/guests";
import PageBookings from "../pages/bookings";
function App() : JSX.Element
{
	return (
		<BrowserRouter>
			<Routes>
				<Route path='/' element={<PageHome />} />
				<Route path='/guests' element={<PageGuests />} />
				<Route path='/bookings' element={<PageBookings />} />
			</Routes>
		</BrowserRouter>
	);
}
export default App;
