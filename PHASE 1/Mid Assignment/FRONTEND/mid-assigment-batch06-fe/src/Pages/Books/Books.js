import { Button, Space, Table, Input, Modal, Tag, Select, Checkbox } from 'antd';
import { Content } from 'antd/lib/layout/layout';

import React, { useContext, useEffect, useState } from 'react';
import { createData, deleteData, getAllData, updateData } from '../../axiosAPIs';
import styles from './Books.module.scss';
import { ExclamationCircleOutlined } from '@ant-design/icons';
import AuthContext from '../../contexts/AuthContext';
import { BOOK, BORROW_BOOKS, CATEGORY } from '../../constants';

const Books = () => {
  const [dataBooks, setDataBooks] = useState('');
  const [dataAdd, setDataAdd] = useState({
    BookName: '',
    CategoryId: '',
  });
  const [dataUpdate, setDataUpdate] = useState({
    BookId: null,
    BookName: '',
    CategoryId: '',
  });
  const [error, setError] = useState({ BookName: '', CategoryId: '' });
  const [buttonDisabled, setButtonDisabled] = useState(true);
  const [isModalOpenAdd, setIsModalOpenAdd] = useState(false);
  const [isModalOpenUpdate, setIsModalOpenUpdate] = useState(false);
  const { auth } = useContext(AuthContext);

  const { confirm } = Modal;

  const [dataCategories, setDataCategories] = useState([]);
  const [dataBorrowBooks, setDataBorrowBooks] = useState([]);

  const getData = async () => {
    const dataBook = await getAllData(BOOK);

    setDataBooks(dataBook);

  };

  useEffect(() => {
    getData();
  }, []);

  const columns = [
    {
      title: 'ID',
      dataIndex: '$id',
      key: '$id',
    },
    {
      title: 'Name',
      dataIndex: 'bookName',
      key: 'bookName',
      sorter: (a, b) => a.bookName.localeCompare(b.bookName),
    },
    {
      title: 'Category Name',
      dataIndex: 'categoryName',
      key: 'categoryName',
      sorter: (a, b) => a.categoryName.localeCompare(b.categoryName),
    },
    {
      title: 'Action',
      key: 'action',
      render: (_, record) => (
        <Space size="middle">
          <Button type="primary" onClick={() => { showModalUpdate(record); }}>
            Update
          </Button>
          <Button type="primary" danger onClick={() => showConfirmDelete(record)}>
            Delete
          </Button>
        </Space>
      ),
      hidden: auth?.roles?.find(roleasd => auth?.roles?.includes(roleasd)) === '0' ? false : true,
    },
    {
      title: 'Borrow Books',
      key: 'borrow-books',
      render: (_, record) => (
        <>
          <Space size="middle">
            <Checkbox onChange={() => onChangeCheckbox(record.bookId)}>Borrow</Checkbox>
          </Space>
        </>
      ),
      hidden: auth?.roles?.find(roleasd => auth?.roles?.includes(roleasd)) === '1' ? false : true,
    },
  ].filter((column) => !column.hidden);

  const [idsSelectArr, setIdsSelectArr] = useState([]);
  console.log(idsSelectArr);
  const output = idsSelectArr.map(BookForeignKey => ({ BookForeignKey }));
  console.log(output)

  const onChangeCheckbox = (bookId) => {
    if (idsSelectArr.includes(bookId)) {
      setIdsSelectArr(idsSelectArr.filter((idSelect) => idSelect !== bookId));
    } else {
      setIdsSelectArr([...idsSelectArr, bookId]);
    }
  };

  const [msg, setMsg] = useState('');
  const handleBorrowBooks = async () => {
    const res = await createData(BORROW_BOOKS, {
      RequestedBy: localStorage.getItem("userName"),
      ListDetails: output
    });

    if (res.code === 'ERR_BAD_REQUEST') {
      setMsg(res.response.data);
    } else {
      setMsg('Borrowing book successfully, waiting for approve');
    }

    getData();
  };

  useEffect(() => {
    if (msg !== '') alert(msg);
  }, [msg]);

  const onSearch = (value) => console.log(value);

  const handleDelete = async (record) => {
    await deleteData(BOOK, record.bookId);
    getData();
  };

  // Add
  const showModalAdd = () => {
    setIsModalOpenAdd(true);
    setError({ BookName: '', CategoryId: '' });
    setDataAdd({
      BookName: '',
      CategoryId: '',
    });
    setButtonDisabled(true);
  };

  const handleOkAdd = async () => {
    setIsModalOpenAdd(false);
    await createData(BOOK, dataAdd);
    getData();
    setDataAdd({
      BookName: '',
      CategoryId: '',
    });
  };

  const handleCancelAdd = () => {
    setIsModalOpenAdd(false);
  };

  const handleBlurAdd = (e) => {
    if (e.target.value) {
      setError({ BookName: '', CategoryId: '' });
    } else {
      setError({ ...error, [e.target.name]: 'This field is required' });
    }
  };

  const handleChangeAdd = (e) => {
    setError({ BookName: '', CategoryId: '' });
    setDataAdd({ ...dataAdd, [e.target.name]: e.target.value });
  };
  // End Add

  // Update
  const showModalUpdate = (record) => {
    setIsModalOpenUpdate(true);
    setError({ BookName: '', CategoryName: '' });
    setDataUpdate({
      BookId: record.bookId,
      BookName: record.bookName,
      CategoryName: record.categoryName,
    });
    setButtonDisabled(true);
  };

  const handleBlurUpdate = (e) => {
    if (e.target.value) {
      setError({ BookName: '', CategoryId: '' });
    } else {
      setError({ ...error, [e.target.name]: 'This field is required' });
    }
  };

  const handleChangeUpdate = (e) => {
    setError({ BookName: '', CategoryId: '' });
    setDataUpdate({ ...dataUpdate, [e.target.name]: e.target.value });
  };

  const handleOkUpdate = async () => {
    setIsModalOpenUpdate(false);
    await updateData(BOOK, dataUpdate);
    getData();
  };

  const handleCancelUpdate = () => {
    setIsModalOpenUpdate(false);
  };

  // End Update

  useEffect(() => {
    if (
      (dataAdd.BookName && dataAdd.CategoryId !== []) ||
      (dataUpdate.BookName && dataUpdate.CategoryId !== [])
    ) {
      setButtonDisabled(false);
    }
  }, [dataAdd, dataUpdate.CategoryId, dataUpdate.BookName]);

  const showConfirmDelete = (record) => {
    confirm({
      title: 'Do you want to delete this book?',
      icon: <ExclamationCircleOutlined />,
      onOk() {
        handleDelete(record);
      },
      onCancel() { },
    });
  };

  const options = dataCategories.map((category) => {
    return { label: category.name, value: category.id };
  });

  return (
    <Content className="container">
      <Space direction="vertical" size="middle" style={{ display: 'flex' }}>
        {' '}
        <div className={styles.headerTable}>
          <h1>List Book</h1>
          <div className="d-flex">
            <Input.Search placeholder="input search" allowClear onSearch={onSearch} className={styles.searchTable} />
            {auth?.roles?.find(roleasd => auth?.roles?.includes(roleasd)) === '0' ? (
              <Button type="primary" onClick={showModalAdd}>
                Add
              </Button>
            ) : (
              <Button type="primary" onClick={handleBorrowBooks}>
                Borrow Books
              </Button>
            )}
          </div>
        </div>
        <Table rowKey={(dataState) => dataState.id} columns={columns} dataSource={dataBooks} />
      </Space>

      <Modal
        title="Create Book"
        open={isModalOpenAdd}
        onOk={handleOkAdd}
        okButtonProps={{ disabled: buttonDisabled }}
        onCancel={handleCancelAdd}
        destroyOnClose={true}
      >
        <Input
          className={styles.inputModal}
          placeholder="Name"
          name="BookName"
          onBlur={handleBlurAdd}
          onChange={handleChangeAdd}
        />
        {error.name && <p className={styles.msgError}>{error.BookName}</p>}
        <Input
          className={styles.inputModal}
          placeholder="Category Id"
          name="CategoryId"
          onBlur={handleBlurAdd}
          onChange={handleChangeAdd}
        />
        {error.author && <p className={styles.msgError}>{error.CategoryId}</p>}
      </Modal>

      <Modal
        title="Update Book"
        open={isModalOpenUpdate}
        onOk={handleOkUpdate}
        okButtonProps={{ disabled: buttonDisabled }}
        onCancel={handleCancelUpdate}
        destroyOnClose={true}
      >
        <Input
          className={styles.inputModal}
          placeholder="Book Name"
          name="BookName"
          value={dataUpdate.BookName}
          onBlur={handleBlurUpdate}
          onChange={handleChangeUpdate}
        />
        {error.name && <p className={styles.msgError}>{error.name}</p>}
        <Input
          className={styles.inputModal}
          placeholder="Categoty Id"
          value={dataUpdate.CategoryId}
          name="CategoryId"
          onBlur={handleBlurUpdate}
          onChange={handleChangeUpdate}
        />
        {error.author && <p className={styles.msgError}>{error.author}</p>}
      </Modal>
    </Content>
  );
};

export default Books;
