import Edit from "../shared/ui/edit";
import Button from "../shared/ui/button";
import './form_read_booking.css';
import { useState, type CSSProperties } from "react";
import ChangeBooking from "../features/change_booking";
import DeleteBooking from "../features/delete_booking";
interface BookingReadFormProps
{
	bId: string;
	bDateArrived: string;
	bDateDeparture: string;
	bNumberRoom: string;
	bName: string;
	bSurname: string;
	bStatus: string;
}
const BookingsReadForm = ({bId, bDateArrived, bDateDeparture, bNumberRoom, bName, bSurname, bStatus}: BookingReadFormProps)=>
{
	const [id, setId] = useState<string>(bId);
	const [dateArrived, setDateArrived] = useState<string>(bDateArrived);
	const [dateDeparture, setDateDeparture] = useState<string>(bDateDeparture);
	const [numberRoom, setNumberRoom] = useState<string>(bNumberRoom);
	const [name, setName] = useState<string>(bName);
	const [surname, setSurname] = useState<string>(bSurname);
	const [status, setStatus] = useState<string>(bStatus);
	const [change, setChange] = useState<boolean>(false);
	const [del, setDel] = useState<boolean>(false);
	const on_del_click = ()=>{setDel(!del);}
	const on_change_click = ()=>{setChange(!change);}
	if (del)
		return (<DeleteBooking dId={id} />);
	if (change)
		return (<ChangeBooking cId={id} cDateArrived={dateArrived} cDateDeparture={dateDeparture}
			cNumberRoom={numberRoom} cName={name} cSurname={surname} cStatus={status} />);
	return (
		<>
			<div className="BookingsReadForm" style={{
				position: 'relative', top:100, height: 200} as CSSProperties
				}>
				<Edit
					left={20}
					top={8}
					label={'id'}
					id={'rbid'}
					style={0}
					value={id}
					onChange={setId}
				/>
				<Edit
					left={300}
					top={8}
					label={'Date Arrived'}
					id={'rbda'}
					style={0}
					value={dateArrived}
					onChange={setDateArrived}
				/>
				<Edit
					left={580}
					top={8}
					label={'Date Departure'}
					id={'rbdd'}
					style={0}
					value={dateDeparture}
					onChange={setDateDeparture}
				/>
				<Edit
					left={860}
					top={8}
					label={'Number Room'}
					id={'rbnr'}
					style={0}
					value={numberRoom}
					onChange={setNumberRoom}
				/>
				<Edit
					left={1140}
					top={8}
					label={'Name'}
					id={'rbn'}
	style={0}
					value={name}
					onChange={setName}
				/>
				<Edit
					left={20}
					top={80}
					label={'Surname'}
					id={'rbsn'}
					style={0}
					value={surname}
					onChange={setSurname}
				/>
				<Edit
					left={300}
					top={80}
					label={'Status'}
					id={'rbs'}
					style={0}
					value={status}
					onChange={setStatus}
				/>
				<Button
					label={'delete'}
					left={1500}
					top={50}
					action={on_del_click}
					style={0}
				/>
				<Button
					label={'change'}
					left={1620}
					top={50}
					action={on_change_click}
					style={0}
				/>
			</div>
		</>
	);
}
export default BookingsReadForm;
