import Button from '../shared/ui/button';
import Text from '../shared/ui/text';
import load_img from '../shared/ui/load_img';
import img_src from '../../img/HomeBG.jpg';
import scroll_to_form_bookings from '../features/scroll_to_form';
import FormBbooking from '../entites/form_booking';
import { useNavigate } from 'react-router-dom';
const PageHome = ()=>
{
	const img = load_img(img_src,0);
	const navigate = useNavigate();
	return (
		<>
		<div className='PageHome'>
			<Button
				label={'Забронировать'}
				left={148}
				top={551.47}
				action={scroll_to_form_bookings}
				style={1}
			/>
			<Button
				label={'номера'}
				left={740}
				top={68.93}
				action={()=>{}}
				style={2}
			/>
			<Button
				label={'гости'}
				left={592}
				top={68.93}
				action={()=>{navigate('/guests', {replace: true})}}
				style={2}
			/>
			<Button
				label={'бронирования'}
				left={900}
				top={68.93}
				action={()=>{navigate('/bookings', {replace:true})}}
				style={2}
			/>
			<Text
				label={'Inkwell Hotel'}
				left={148}
				top={68.93}
				style={0}
			/>
			<Text
				label={'Inkwell Hotel'}
				left={196}
				top={302.8}
				style={1}
			/>
			<Text
				label={'Добро'}
				left={148}
				top={206.8}
				style={2}
			/>
			<Text
				label={'пожаловать'}
				left={148}
				top={256.8}
				style={2}
			/>
			<Text
				label={'в'}
				left={148}
				top={302.8}
				style={2}
			/>
			<Text
				label={'У нас вы отлично проведете вермя'}
				left={148}
				top={413.6}
				style={3}
			/>
			<Text
				label={'и наберетесь сил перед новым днем'}
				left={148}
				top={437.6}
				style={3}
			/>
			{img}
			</div>
				<FormBbooking />
		</>
	);
}
export default PageHome;
