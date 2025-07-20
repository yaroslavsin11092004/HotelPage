import Button from "../shared/ui/button";
import { useNavigate } from "react-router-dom";
import GuestsList from "../features/get_guests";
import { useState } from "react";
import FormAddGuest from "../entites/form_add_guest";
const PageGuests = ()=>
{
	const [isAdd, setIsAdd] = useState<boolean>(false);
	const on_add_click = ()=>{setIsAdd(true);}
	const navigate = useNavigate();
	if(isAdd){return <>
		<FormAddGuest />
		<Button
			label={'<- назад'}
			left={50}
			top={50}
			action={()=>{window.location.reload()}}
			style={2}
		/>
		</>;}
	return (
		<>
		<div className="PageGuests">
			<Button
				label={'<- назад'}
				left={50}
				top={50}
				action={()=>{navigate('/',{replace:true})}}
				style={2}
			/>
			<Button
				label={'add'}
				left={1630}
				top={60}
				action={on_add_click}
				style={0}
			/>
			<GuestsList />
		</div>
		</>
	);
}
export default PageGuests;
