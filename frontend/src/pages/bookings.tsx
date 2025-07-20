import { useNavigate } from "react-router-dom";
import Button from "../shared/ui/button";
import BookingsList from "../features/get_bookings";
const PageBookings = ()=>
{
	const navigate = useNavigate();
	return (
		<div>
			<Button
				label={'<- назад'}
				left={50}
				top={50}
				action={()=>{navigate('/', {replace:true})}}
				style={2}
			/>
			<BookingsList />
			</div>
	);
}
export default PageBookings;

