import {type JSX,type CSSProperties, useState} from "react";
import FormAddBooking from "./from_add_booking";
import Edit from "../shared/ui/edit";
import Button from "../shared/ui/button";
import FreeRoomList from "../features/get_free_room";
import './form_booking.css';
const FormBbooking = (): JSX.Element =>
{
	const [dateArrived, setDateArrived] = useState<string>('');
	const [dateDeparture, setDateDeparture] = useState<string>('');
	const [click, setClick] = useState<boolean>(false);
	const on_click = (): void => {setClick(!click);}
	const [hasError, setHasError] = useState<boolean>(false);
	return (
		<>
		<div className="form_booking" id = 'fb' style={
			{position:"relative", width: 848, height:128}as CSSProperties
			}>
			<Edit
				left={20}
				top={8}
				label={'Дата заезда'}
				id={'da'}
				style={0}
				value={dateArrived}
				onChange={setDateArrived}
			/>
			<Edit 
				left={340}
				top={8}
				label={'Дата выезда'}
				id={'dd'}
				style={0}
				value={dateDeparture}
				onChange={setDateDeparture}
			/>
			<Button
				label={'найти'}
				left={720}
				top={60}
				action={on_click}
				style={0}
			/>
		</div>
		<div>
			{click && <><FreeRoomList date_arrived={dateArrived} date_departure={dateDeparture} onErrorChange={setHasError} />{hasError&&<FormAddBooking onClickChange={setClick} onDateArrivedCahnge={setDateArrived} onDateDepartureChange={setDateDeparture} dateArrived={dateArrived} dateDeparture={dateDeparture}/>}</>}
		</div>
		</>
	);
}
export default FormBbooking;
