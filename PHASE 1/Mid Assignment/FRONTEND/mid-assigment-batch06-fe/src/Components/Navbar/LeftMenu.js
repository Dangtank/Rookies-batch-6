import React, { useContext } from 'react';
import { Menu, Grid } from 'antd';
import { Link } from 'react-router-dom';
import AuthContext from '../../contexts/AuthContext';
const { useBreakpoint } = Grid;

const LeftMenu = () => {
  const { md } = useBreakpoint();
  const { auth } = useContext(AuthContext);

  console.log('auth', auth);
  const items = [
    {
      label: <Link to={'/'}>Home</Link>,
      key: 'home',
    },
    {
      label: <Link to={'/categories'}>Categories</Link>,
      key: 'categories',
    },
    {
      label: <Link to={'/books'}>Books</Link>,
      key: 'books',
    },
    {
      label: <Link to={'/list-request'}>List Request</Link>,
      key: 'list-request',
      // hidden: auth?.roles?.find(roleasd => auth?.roles?.includes(roleasd)) === '0' ? false : true,
    },
    {
      label: <Link to={'/book-borrowed'}>Book Borrowed</Link>,
      key: 'book-borrowed',
    },
  ];
  return <Menu mode={md ? 'horizontal' : 'inline'} items={items} />;
};

export default LeftMenu;
